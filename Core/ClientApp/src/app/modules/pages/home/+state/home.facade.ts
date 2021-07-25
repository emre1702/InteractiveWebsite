import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from '.';
import * as homeActions from './home.actions';
import * as homeSelectors from './home.selectors';

@Injectable()
export class HomeFacade {
    news$ = this.store.select(homeSelectors.selectNews);

    constructor(private readonly store: Store<State>) {}

    loadNews() {
        this.store.dispatch(homeActions.loadNews());
    }
}
