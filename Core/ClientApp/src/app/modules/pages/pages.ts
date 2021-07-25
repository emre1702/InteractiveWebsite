import routerRoutes from 'src/app/router.routes';

const pages: { text: string; route: string }[] = [
    { text: $localize`Home`, route: routerRoutes.home },
    { text: $localize`News`, route: routerRoutes.news },
];

export default pages;
