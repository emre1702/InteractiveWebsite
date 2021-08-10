import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponent } from './components/news/news.component';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../material/material.module';

@NgModule({
    declarations: [NewsComponent],
    imports: [CommonModule, FormsModule, MaterialModule],
})
export class NewsModule {}
