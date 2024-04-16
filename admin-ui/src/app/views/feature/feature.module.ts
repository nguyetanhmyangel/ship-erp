import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FeatureRoutingModule } from './feature-routing.module';
import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { PostComponent } from './posts/post.component';


@NgModule({
  declarations: [
     PostComponent
  ],
  imports: [
    CommonModule,
    FeatureRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule,
  ]
})
export class FeatureModule {
}
