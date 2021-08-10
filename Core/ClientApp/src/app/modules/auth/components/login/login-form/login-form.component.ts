import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import routerRoutes from 'src/app/router.routes';
import { ExternalProvider } from '../../../enums/external-provider';
import { LoginResultStatus } from '../../../enums/login-result-status';
import { getReturnUrl } from '../../../helpers/url.helper';
import { RegisterLoginData } from '../../../models/register-login-data';
import { AuthService } from '../../../services/auth.service';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent {
    formGroup = new FormGroup({
        // eslint-disable-next-line @typescript-eslint/unbound-method
        email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(320)]),
        // eslint-disable-next-line @typescript-eslint/unbound-method
        password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(255)]),
        rememberMe: new FormControl(false),
    });

    showPassword: boolean;
    isSubmiting: boolean;
    externalProviderEnum = ExternalProvider;

    constructor(
        private readonly router: Router,
        private readonly activatedRoute: ActivatedRoute,
        private readonly authService: AuthService,
        private readonly snackBar: MatSnackBar,
    ) {}

    submit() {
        this.isSubmiting = true;
        this.authService
            .login(this.formGroup.value as unknown as RegisterLoginData)
            .pipe(finalize(() => (this.isSubmiting = false)))
            .subscribe((result) => {
                if (result.status === LoginResultStatus.Succeeded) {
                    this.router.navigateByUrl(getReturnUrl(this.activatedRoute), { replaceUrl: true });
                } else {
                    this.snackBar.open(this.getErrorMessage(result.status), $localize`OK`);
                }
            });
    }

    toggleShowPassword(event: MouseEvent) {
        event.stopPropagation();
        this.showPassword = !this.showPassword;
    }

    switchToRegister() {
        this.router.navigate(routerRoutes.auth.register.split('/'), {
            replaceUrl: true,
            queryParams: {
                ['returnUrl']: getReturnUrl(this.activatedRoute),
            },
        });
    }

    private getErrorMessage(status: LoginResultStatus): string {
        switch (status) {
            case LoginResultStatus.NoAccount:
                return $localize`This account does not exist.`;
        }
    }
}
