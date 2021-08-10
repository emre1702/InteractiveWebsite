import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromIndex from '.';

export const selectState = createFeatureSelector<fromIndex.State>(fromIndex.featureKey);

export const selectNavigations = createSelector(selectState, (state) => state.navigations);
