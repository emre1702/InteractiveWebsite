import { News } from '../models/news';

export const featureKey = 'home';

export interface State {
    news: News[];
}
