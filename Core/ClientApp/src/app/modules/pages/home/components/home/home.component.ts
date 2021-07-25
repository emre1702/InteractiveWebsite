import { Component } from '@angular/core';
import { HomeFacade } from '../../+state/home.facade';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
    constructor(readonly facade: HomeFacade) {
        facade.loadNews();
    }
}
