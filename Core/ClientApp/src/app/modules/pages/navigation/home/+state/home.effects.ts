import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { catchError, map, mergeMap, withLatestFrom } from 'rxjs/operators';
import { State } from '.';
import { HomeService } from '../services/home.service';
import * as homeActions from './home.actions';
import * as homeSelectors from './home.selectors';

@Injectable()
export class HomeEffects {
    loadNews$ = createEffect(() =>
        this.actions$.pipe(
            ofType(homeActions.loadNews),
            withLatestFrom(this.store.select(homeSelectors.selectLatestNewsId)),
            mergeMap(([_, latestNewsId]) =>
                this.service.loadNews(latestNewsId).pipe(
                    map((news) => homeActions.loadNewsSuccessful({ news })),
                    catchError((error) => of(homeActions.loadNewsFailure({ error }))),
                ),
            ),
        ),
    );

    constructor(private readonly actions$: Actions, private readonly service: HomeService, private readonly store: Store<State>) {}
}
