import { NgModule } from '@angular/core';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginFormComponent } from './components/login/login-form/login-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import routerRoutes from 'src/app/router.routes';
import { MaterialModule } from '../material/material.module';
import { RegisterFormComponent } from './components/register/register-form/register-form.component';

@NgModule({
    declarations: [LoginComponent, RegisterComponent, LoginFormComponent, RegisterFormComponent],
    imports: [
        CommonModule,
        FormsModule,
        MaterialModule,
        // SocialLoginModule,
        RouterModule.forChild([
            { path: routerRoutes.auth.login, component: LoginComponent },
            { path: routerRoutes.auth.register, component: RegisterComponent },
        ]),
    ],
    /*providers: [
        {
            provide: 'SocialAuthServiceConfig',
            useValue: {
                //Todo: Check this
                autoLogin: false,
                providers: [
                    {
                        id: GoogleLoginProvider.PROVIDER_ID,
                        provider: new GoogleLoginProvider(environment.cliendIds.google, { scope: 'email' }),
                    },
                    {
                        id: FacebookLoginProvider.PROVIDER_ID,
                        provider: new FacebookLoginProvider(environment.cliendIds.facebook, { scope: 'email' }),
                    },
                ],
            } as SocialAuthServiceConfig,
        },
    ],*/
})
export class AuthModule {}
