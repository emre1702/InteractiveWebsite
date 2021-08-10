import { createReducer, on } from '@ngrx/store';
import { State } from '.';
import { NavigationItem } from '../enums/navigation-item';
import * as pagesActions from './pages.actions';

export const reducers = createReducer<State>(
    { navigations: [] },

    on(pagesActions.loadNavigationsSuccess, (state, action) => ({ ...state, navigations: action.navigations.map((n) => NavigationItem[n]) })),
);
