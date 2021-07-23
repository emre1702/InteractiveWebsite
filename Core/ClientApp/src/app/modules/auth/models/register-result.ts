export interface RegisterResult {
    type: 'register';

    succeeded: boolean;
    errors?: string[];
}
