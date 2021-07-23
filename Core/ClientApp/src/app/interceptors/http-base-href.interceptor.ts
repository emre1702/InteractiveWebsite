import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpBaseHrefInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        const baseHref = document.head.getElementsByTagName('base')[0].getAttribute('href').substring(0, -1);
        let url = req.url;
        if (url.startsWith(baseHref)) url = url.substring(baseHref.length);
        const requestWithoutBaseHref = req.clone({ url });
        return next.handle(requestWithoutBaseHref);
    }
}
