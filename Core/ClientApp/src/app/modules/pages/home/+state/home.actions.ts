import { createAction, props } from '@ngrx/store';
import { News } from '../models/news';

export const loadNews = createAction('[Home] Load News');
export const loadNewsSuccessful = createAction('[Home] Load News Successful', props<{ news: News[] }>());
export const loadNewsFailure = createAction('[Home] Load News Failure ', props<{ error: unknown }>());
