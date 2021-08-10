import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { PagesService } from '../services/pages.service';
import * as pagesActions from './pages.actions';

@Injectable()
export class PagesEffects {
    loadNavigations$ = createEffect(() =>
        this.actions$.pipe(
            ofType(pagesActions.loadNavigations),
            switchMap(() =>
                this.service.loadNavigations().pipe(
                    map((navigations) => pagesActions.loadNavigationsSuccess({ navigations })),
                    catchError((error) => of(pagesActions.loadNavigationsFailure({ error }))),
                ),
            ),
        ),
    );

    constructor(private readonly actions$: Actions, private readonly service: PagesService) {}
}
