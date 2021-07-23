import { LoginResultStatus } from '../enums/login-result-status';

export interface LoginResult {
    type: 'login';

    status: LoginResultStatus;
    token?: string;
}
