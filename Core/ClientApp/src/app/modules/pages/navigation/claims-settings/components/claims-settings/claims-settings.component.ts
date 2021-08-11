import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpService } from 'src/app/modules/shared/services/http.service';
import claimsSettingsRoutes from '../../claims-settings.routes';
import { ClaimsSettingsWebConfiguration } from '../../models/claims-settings-web-configuration';

@Component({
    selector: 'app-claims-settings',
    templateUrl: './claims-settings.component.html',
    styleUrls: ['./claims-settings.component.scss'],
})
export class ClaimsSettingsComponent implements OnInit {
    claimsSettings$ = new Subject<ClaimsSettingsWebConfiguration[]>();
    readonly changedClaimsSettings: ClaimsSettingsWebConfiguration[] = [];
    readonly adminLevel = Math.pow(2, 31) - 1;

    private saving: boolean;

    constructor(private readonly httpService: HttpService) {}

    ngOnInit() {
        this.httpService
            .get<ClaimsSettingsWebConfiguration[]>(claimsSettingsRoutes.get.claimsSettings)
            .subscribe((claimsSettings) => this.claimsSettings$.next(claimsSettings));
    }

    saveChangedClaimsSettings() {
        if (!this.changedClaimsSettings.length) return;
        if (this.saving) return;

        this.saving = true;
        this.httpService
            .post<ClaimsSettingsWebConfiguration[]>(claimsSettingsRoutes.post.claimsSettings, this.changedClaimsSettings)
            .pipe(finalize(() => (this.saving = false)))
            .subscribe((claimsSettings) => {
                this.claimsSettings$.next(claimsSettings);
                this.changedClaimsSettings.length = 0;
            });
    }

    claimSettingsChanged(claimSettings: ClaimsSettingsWebConfiguration, minLevel: number) {
        claimSettings.minLevel = minLevel;
        const previousChangedClaimSettings = this.changedClaimsSettings.find(
            (s) => s.claimId === claimSettings.claimId && s.navigation == claimSettings.navigation,
        );
        if (previousChangedClaimSettings) previousChangedClaimSettings.minLevel = minLevel;
        else {
            const changedClaimSettings: ClaimsSettingsWebConfiguration = { ...claimSettings, info: undefined, minLevel };
            this.changedClaimsSettings.push(changedClaimSettings);
        }
    }
}
