import routerRoutes from 'src/app/router.routes';
import { NavigationItem } from './enums/navigation-item';

const navigations: { [key: number]: { text: string; route: string } } = {
    [NavigationItem.Home]: { text: $localize`Home`, route: routerRoutes.home },
    [NavigationItem.Members]: { text: $localize`Members`, route: routerRoutes.members },
    [NavigationItem.News]: { text: $localize`News`, route: routerRoutes.news },
};

export default navigations;
