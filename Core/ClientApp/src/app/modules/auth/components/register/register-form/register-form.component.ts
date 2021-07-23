import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import routerRoutes from 'src/app/router.routes';
import { getReturnUrl } from '../../../helpers/url.helper';
import { RegisterLoginData } from '../../../models/register-login-data';
import { AuthService } from '../../../services/auth.service';

@Component({
    selector: 'app-register-form',
    templateUrl: './register-form.component.html',
    styleUrls: ['./register-form.component.scss'],
})
export class RegisterFormComponent {
    formGroup = new FormGroup({
        // eslint-disable-next-line @typescript-eslint/unbound-method
        email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(320)]),
        // eslint-disable-next-line @typescript-eslint/unbound-method
        password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(255)]),
        // eslint-disable-next-line @typescript-eslint/unbound-method
        confirmPassword: new FormControl('', [Validators.required]),
    });

    showPassword: boolean;
    showConfirmPassword: boolean;
    isSubmiting: boolean;

    constructor(private readonly router: Router, private readonly activatedRoute: ActivatedRoute, private readonly authService: AuthService) {}

    submit() {
        this.formGroup.controls.confirmPassword.setValue('');
        this.authService
            .register(this.formGroup.value as unknown as RegisterLoginData)
            .pipe(finalize(() => (this.isSubmiting = false)))
            .subscribe((result) => {
                if (result.type === 'register') {
                    this.switchToLogin();
                } else {
                    this.router.navigateByUrl(getReturnUrl(this.activatedRoute), { replaceUrl: true });
                }
            });
    }

    toggleShowPassword(event: MouseEvent) {
        event.stopPropagation();
        this.showPassword = !this.showPassword;
    }

    toggleShowConfirmPassword(event: MouseEvent) {
        event.stopPropagation();
        this.showConfirmPassword = !this.showConfirmPassword;
    }

    isPasswordConfirmed(): boolean {
        const isConfirmed = this.formGroup.controls.password.value === this.formGroup.controls.confirmPassword.value;
        if (!isConfirmed) this.formGroup.controls.confirmPassword.setErrors({ notSame: true });
        else this.formGroup.controls.confirmPassword.setErrors(null);
        return isConfirmed;
    }

    switchToLogin() {
        this.router.navigate(routerRoutes.auth.login.split('/'), {
            replaceUrl: true,
            queryParams: {
                ['returnUrl']: getReturnUrl(this.activatedRoute),
            },
        });
    }
}
