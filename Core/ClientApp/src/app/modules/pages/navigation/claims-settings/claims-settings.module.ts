import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { ClaimsSettingsComponent } from './components/claims-settings/claims-settings.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [ClaimsSettingsComponent],
    imports: [CommonModule, FormsModule, MaterialModule],
})
export class ClaimsSettingsModule {}
