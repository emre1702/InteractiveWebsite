import { TestBed, inject } from '@angular/core/testing';

import { AuthGuard } from './auth.guard';

describe('AutheGuard', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [AuthGuard],
        });
    });

    it('should create', inject([AuthGuard], (guard: AuthGuard) => {
        expect(guard).toBeTruthy();
    }));
});
