import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import homeRoutes from '../home.routes';
import { News } from '../models/news';

@Injectable()
export class HomeService {
    constructor(private readonly httpClient: HttpClient) {}

    loadNews(loadedLastNewsId?: number): Observable<News[]> {
        return this.httpClient.get<News[]>(homeRoutes.get.news, { params: { loadedLastNewsId } });
    }
}
