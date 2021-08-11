import { NavigationItem } from '../../../enums/navigation-item';

export interface ClaimsSettingsWebConfiguration {
    claimId: string;
    navigation: NavigationItem;
    info?: string;
    minLevel: number;
}
