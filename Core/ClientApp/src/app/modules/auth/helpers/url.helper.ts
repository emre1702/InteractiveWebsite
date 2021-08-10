import { ActivatedRoute } from '@angular/router';
import routerRoutes from 'src/app/router.routes';

export function getReturnUrl(activatedRoute: ActivatedRoute): string {
    const fromQuery = (activatedRoute.snapshot.queryParams as { returnUrl: string }).returnUrl;
    // If the url is coming from the query string, check that is either
    // a relative url or an absolute url
    if (fromQuery && !(fromQuery.startsWith(`${window.location.origin}/`) || /\/([^\/].*)?/.test(fromQuery))) {
        // This is an extra check to prevent open redirects.
        throw new Error('Invalid return url. The return url needs to have the same origin as the current page.');
    }
    return fromQuery || routerRoutes.home;
}
