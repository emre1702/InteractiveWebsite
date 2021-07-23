import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import routerRoutes from 'src/app/router.routes';
import { AuthGuard } from '../auth/guards/auth.guard';
import { HomeComponent } from './components/home/home.component';

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, RouterModule.forChild([{ path: routerRoutes.home, component: HomeComponent, canActivate: [AuthGuard], pathMatch: 'full' }])],
})
export class HomeModule {}
