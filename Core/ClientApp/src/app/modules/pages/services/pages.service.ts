import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../../shared/services/http.service';
import pagesRoutes from '../pages.routes';

@Injectable()
export class PagesService {
    constructor(private readonly httpService: HttpService) {}

    loadNavigations(): Observable<string[]> {
        return this.httpService.get<string[]>(pagesRoutes.get.navigations);
    }
}
