import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MembersMainComponent } from './components/main/members-main.component';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { MembersTableComponent } from './components/members-table/members-table.component';
import { MembersTableService } from './services/members-table.service';

@NgModule({
    declarations: [MembersMainComponent, MembersTableComponent],
    imports: [CommonModule, FormsModule, MaterialModule],
    providers: [MembersTableService],
})
export class MembersModule {}
