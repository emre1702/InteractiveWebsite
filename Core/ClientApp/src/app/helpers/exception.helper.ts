import { HttpErrorResponse } from '@angular/common/http';

export function getErrorMessage(err: string | HttpErrorResponse | unknown): string {
    if (typeof err === 'string') return err;
    if (err instanceof HttpErrorResponse) return err.message;
    return String(err);
}
