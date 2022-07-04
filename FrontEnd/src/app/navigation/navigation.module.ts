import { HeaderComponent } from './header/header.component';

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
    declarations: [
        HeaderComponent,
        HomeComponent,
        FooterComponent
    ],
    imports: [ 
        CommonModule,
        RouterModule
    ],
    exports: [
        HeaderComponent,
        HomeComponent,
        FooterComponent
    ],
    providers: [],
})
export class NavigationModule {}