import { createAction, props } from '@ngrx/store';

export const loadNavigations = createAction('[Pages] Load Navigations');
export const loadNavigationsSuccess = createAction('[Pages] Load Navigations Success', props<{ navigations: string[] }>());
export const loadNavigationsFailure = createAction('[Pages] Load Navigations Failure', props<{ error: unknown }>());
