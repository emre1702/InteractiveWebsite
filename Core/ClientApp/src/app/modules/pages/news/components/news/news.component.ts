import { Component } from '@angular/core';
import { HttpService } from 'src/app/modules/shared/services/http.service';
import newsRoutes from '../../news.routes';

@Component({
    selector: 'app-news',
    templateUrl: './news.component.html',
    styleUrls: ['./news.component.scss'],
})
export class NewsComponent {
    content: string;
    resultMessage: string;

    constructor(private readonly httpService: HttpService) {}

    createNews() {
        this.resultMessage = $localize`Sending ...`;
        this.httpService.post(newsRoutes.post.news, { content: this.content }).subscribe(
            () => (this.resultMessage = $localize`The news was sent successfully.`),
            () => (this.resultMessage = $localize`The news could not be sent.`),
        );
    }
}
