import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import pages from './modules/pages/pages';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
})
export class AppComponent {
    pages = pages;
    constructor(titleService: Title) {
        titleService.setTitle($localize`Interactive Website`);
    }
}
