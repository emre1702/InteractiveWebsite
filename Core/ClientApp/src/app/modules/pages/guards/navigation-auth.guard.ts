import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { first, map, tap } from 'rxjs/operators';
import routerRoutes from 'src/app/router.routes';
import { PagesFacade } from '../+state/pages.facade';
import navigations from '../navigations';

@Injectable({
    providedIn: 'root',
})
export class NavigationAuthGuard implements CanActivate {
    constructor(private readonly router: Router, private readonly facade: PagesFacade) {}

    canActivate(next: ActivatedRouteSnapshot, _state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        const route = next.routeConfig.path;
        if (route === routerRoutes.home) return true;

        const key = Number(Object.keys(navigations).find((n) => navigations[n].route === route));
        if (key == undefined) return false;

        return this.facade.navigations$.pipe(
            first(),
            map((allowedNavigations) => allowedNavigations.some((a) => a === key)),
            tap((canNavigate) => this.handleResult(canNavigate)),
        );
    }

    private handleResult(canNavigate: boolean) {
        if (!canNavigate) {
            this.router.navigate(routerRoutes.home.split('/'));
        }
    }
}
