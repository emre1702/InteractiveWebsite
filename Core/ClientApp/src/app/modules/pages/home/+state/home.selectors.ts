import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromIndex from '.';

export const selectState = createFeatureSelector<fromIndex.State>(fromIndex.featureKey);

export const selectNews = createSelector(selectState, (state) => state.news);
export const selectLatestNewsId = createSelector(selectState, (state) => Math.max(0, ...state.news.map((n) => n.id)));
