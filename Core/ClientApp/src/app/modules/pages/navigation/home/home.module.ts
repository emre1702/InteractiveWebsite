import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { StoreModule } from '@ngrx/store';
import * as fromHome from './+state';
import { reducers } from './+state/home.reducers';
import { HomeService } from './services/home.service';
import { EffectsModule } from '@ngrx/effects';
import { HomeEffects } from './+state/home.effects';
import { HomeFacade } from './+state/home.facade';
import { MaterialModule } from 'src/app/modules/material/material.module';

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, MaterialModule, StoreModule.forFeature(fromHome.featureKey, reducers), EffectsModule.forFeature([HomeEffects])],
    providers: [HomeService, HomeFacade],
})
export class HomeModule {}
