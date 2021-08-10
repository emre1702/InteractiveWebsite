import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import routerRoutes from 'src/app/router.routes';
import { AuthService } from '../auth/services/auth.service';
import { PagesFacade } from './+state/pages.facade';
import { NavigationItem } from './enums/navigation-item';
import navigations from './navigations';

@Component({
    selector: 'app-page',
    templateUrl: './page.component.html',
})
export class PageComponent implements OnInit, OnDestroy {
    readonly navigations = navigations;
    isSubmiting: boolean;

    private readonly _destroySubject = new Subject();

    constructor(readonly authService: AuthService, private readonly router: Router, readonly facade: PagesFacade) {}

    ngOnInit() {
        this.authService.loggedInStatusChange$.pipe(takeUntil(this._destroySubject)).subscribe((isLoggedIn) => {
            if (isLoggedIn) this.facade.loadNavigations();
        });
    }

    ngOnDestroy() {
        this._destroySubject.next();
    }

    logout() {
        this.isSubmiting = true;
        this.authService
            .logout()
            .pipe(finalize(() => (this.isSubmiting = false)))
            .subscribe(() => {
                this.router.navigateByUrl(routerRoutes.auth.login, { replaceUrl: true });
            });
    }
}
