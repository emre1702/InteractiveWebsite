import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import routerRoutes from 'src/app/router.routes';
import { AuthModule } from '../auth/auth.module';
import { LoginComponent } from '../auth/components/login/login.component';
import { RegisterComponent } from '../auth/components/register/register.component';
import { AuthGuard } from '../auth/guards/auth.guard';
import { MaterialModule } from '../material/material.module';
import { featureKey } from './+state';
import { PagesEffects } from './+state/pages.effects';
import { PagesFacade } from './+state/pages.facade';
import { reducers } from './+state/pages.reducers';
import { NavigationAuthGuard } from './guards/navigation-auth.guard';
import { ClaimsSettingsModule } from './navigation/claims-settings/claims-settings.module';
import { ClaimsSettingsComponent } from './navigation/claims-settings/components/claims-settings/claims-settings.component';
import { HomeComponent } from './navigation/home/components/home/home.component';
import { HomeModule } from './navigation/home/home.module';
import { NewsComponent } from './navigation/news/components/news/news.component';
import { NewsModule } from './navigation/news/news.module';
import { PageComponent } from './page.component';
import { PagesService } from './services/pages.service';
import { MembersModule } from './navigation/members/members.module';
import { MembersMainComponent } from './navigation/members/components/main/members-main.component';

@NgModule({
    declarations: [PageComponent],
    imports: [
        HomeModule,
        NewsModule,
        ClaimsSettingsModule,
        MembersModule,

        EffectsModule.forFeature([PagesEffects]),
        StoreModule.forFeature(featureKey, reducers),

        AuthModule,
        MaterialModule,
        RouterModule.forRoot([
            { path: routerRoutes.auth.login, component: LoginComponent },
            { path: routerRoutes.auth.register, component: RegisterComponent },

            { path: routerRoutes.home, component: HomeComponent, canActivate: [NavigationAuthGuard, AuthGuard] },
            { path: routerRoutes.news, component: NewsComponent, canActivate: [NavigationAuthGuard, AuthGuard] },
            { path: routerRoutes.members, component: MembersMainComponent, canActivate: [NavigationAuthGuard, AuthGuard] },
            { path: routerRoutes.claimsSettings, component: ClaimsSettingsComponent, canActivate: [NavigationAuthGuard, AuthGuard] },

            { path: '**', redirectTo: routerRoutes.home },
        ]),
    ],
    exports: [PageComponent],
    providers: [PagesFacade, PagesService],
})
export class PagesModule {}
