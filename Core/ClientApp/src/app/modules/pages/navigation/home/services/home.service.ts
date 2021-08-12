import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/modules/shared/services/http.service';
import homeRoutes from '../home.routes';
import { News } from '../models/news';

@Injectable()
export class HomeService {
    constructor(private readonly httpService: HttpService) {}

    loadNews(loadedLastNewsId?: number): Observable<News[]> {
        return this.httpService.get<News[]>(homeRoutes.get.news, { params: { loadedLastNewsId } });
    }
}
