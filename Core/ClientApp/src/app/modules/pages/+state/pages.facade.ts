import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from '.';
import * as pagesSelectors from './pages.selectors';
import * as pagesActions from './pages.actions';

@Injectable()
export class PagesFacade {
    navigations$ = this.store.select(pagesSelectors.selectNavigations);

    constructor(private readonly store: Store<State>) {}

    loadNavigations() {
        this.store.dispatch(pagesActions.loadNavigations());
    }
}
