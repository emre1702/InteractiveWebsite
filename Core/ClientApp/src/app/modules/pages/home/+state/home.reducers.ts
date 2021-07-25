import { createReducer, on } from '@ngrx/store';
import { State } from '.';
import * as actions from './home.actions';

export const reducers = createReducer<State>(
    { news: [] },

    on(actions.loadNewsSuccessful, (state, action) => ({
        ...state,
        news: [...action.news, ...state.news],
    })),
);
