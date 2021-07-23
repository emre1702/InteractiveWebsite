import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginResultStatus } from '../../enums/login-result-status';
import { getReturnUrl } from '../../helpers/url.helper';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
    showLoginForm: boolean;

    constructor(private readonly authService: AuthService, private readonly router: Router, private readonly activatedRoute: ActivatedRoute) {}

    ngOnInit() {
        this.authService.checkIsLoggedIn().subscribe((result) => {
            if (result.status === LoginResultStatus.Succeeded) this.router.navigateByUrl(getReturnUrl(this.activatedRoute), { replaceUrl: true });
            else this.showLoginForm = true;
        });
    }
}
