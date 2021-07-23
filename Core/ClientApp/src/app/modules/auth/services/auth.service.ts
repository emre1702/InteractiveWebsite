import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { LoginResultStatus } from '../enums/login-result-status';
import { AuthUser } from '../models/auth-user';
import { LoginResult } from '../models/login-result';
import { RegisterLoginData } from '../models/register-login-data';
import { RegisterResult } from '../models/register-result';
import authRoutes from '../auth.routes';
import { mergeMap, tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    user: AuthUser;

    private registerErrors = new Subject<string[]>();
    registerErrors$ = this.registerErrors.asObservable();

    constructor(private readonly httpClient: HttpClient) {}

    login(data: RegisterLoginData): Observable<LoginResult> {
        return this.httpClient.post<LoginResult>(authRoutes.post.login, data).pipe(tap((result) => this.onLogIn(result)));
    }

    register(data: RegisterLoginData): Observable<RegisterResult | LoginResult> {
        return this.httpClient.post<RegisterResult>(authRoutes.post.register, data).pipe(mergeMap((result) => this.onRegister(data, result)));
    }

    isLoggedIn() {
        return !!this.user;
    }

    checkIsLoggedIn(): Observable<LoginResult | undefined> {
        return this.httpClient.get<LoginResult>(authRoutes.get.checkIsLoggedIn).pipe(tap((result) => this.onLogIn(result)));
    }

    private onLogIn(result: LoginResult) {
        switch (result.status) {
            case LoginResultStatus.Succeeded:
                this.user = { token: result.token };
                break;
            case LoginResultStatus.NotAllowed:
                break;
            default:
                throw new Error(`OnLogIn status ${LoginResultStatus[result.status]} not implemented.`);
        }
    }

    private onRegister(data: RegisterLoginData, result: RegisterResult): Observable<RegisterResult | LoginResult> {
        if (result.succeeded) {
            //Todo: Add email confirmation on internal register (this one here)
            return this.login(data);
        } else this.registerErrors.next(result.errors ?? []);
        return of(result);
    }
}
