import { Component } from '@angular/core';
import { AuthService } from '../auth/services/auth.service';
import pages from './pages';

@Component({
    selector: 'app-page',
    templateUrl: './page.component.html',
})
export class PageComponent {
    readonly pages = pages;

    constructor(readonly authService: AuthService) {}
}
