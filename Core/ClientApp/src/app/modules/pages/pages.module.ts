import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import routerRoutes from 'src/app/router.routes';
import { AuthModule } from '../auth/auth.module';
import { LoginComponent } from '../auth/components/login/login.component';
import { RegisterComponent } from '../auth/components/register/register.component';
import { AuthGuard } from '../auth/guards/auth.guard';
import { MaterialModule } from '../material/material.module';
import { HomeComponent } from './home/components/home/home.component';
import { HomeModule } from './home/home.module';
import { NewsComponent } from './news/components/news/news.component';
import { NewsModule } from './news/news.module';
import { PageComponent } from './page.component';

@NgModule({
    declarations: [PageComponent],
    imports: [
        HomeModule,
        NewsModule,

        AuthModule,
        MaterialModule,
        RouterModule.forRoot([
            { path: routerRoutes.auth.login, component: LoginComponent },
            { path: routerRoutes.auth.register, component: RegisterComponent },

            { path: routerRoutes.home, component: HomeComponent, canActivate: [AuthGuard] },
            { path: routerRoutes.news, component: NewsComponent, canActivate: [AuthGuard] },

            { path: '**', redirectTo: routerRoutes.home },
        ]),
    ],
    exports: [PageComponent],
})
export class PagesModule {}
