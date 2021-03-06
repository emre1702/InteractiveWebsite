import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { HttpBaseHrefInterceptor } from './interceptors/http-base-href.interceptor';
import { AuthInterceptor } from './modules/auth/interceptors/auth.interceptor';
import { PagesModule } from './modules/pages/pages.module';

@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        EffectsModule.forRoot([]),
        StoreModule.forRoot({}, {}),
        StoreDevtoolsModule.instrument({ maxAge: 25, autoPause: true }),

        PagesModule,
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: HttpBaseHrefInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
