import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import routerRoutes from 'src/app/router.routes';

@Injectable({
    providedIn: 'root',
})
export class AuthGuard implements CanActivate {
    constructor(private readonly authService: AuthService, private readonly router: Router) {}

    canActivate(_next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        const isAuthenticated = !!this.authService.user;
        this.handleAuthorization(isAuthenticated, state);
        return isAuthenticated;
    }

    private handleAuthorization(isAuthenticated: boolean, state: RouterStateSnapshot) {
        if (!isAuthenticated) {
            this.router.navigate(routerRoutes.auth.login.split('/'), {
                queryParams: {
                    ['returnUrl']: state.url,
                },
            });
        }
    }
}
