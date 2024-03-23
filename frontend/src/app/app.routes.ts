import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { BlankLayoutComponent } from './components/blank-layout/blank-layout.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [{ path: '', component: HomeComponent, pathMatch: 'full' }],
  },
  {
    path: '',
    component: BlankLayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent,
        pathMatch: 'full',
      },
    ],
  },
];
