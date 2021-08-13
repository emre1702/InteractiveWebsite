import { Component } from '@angular/core';
import { MemberData } from '../../models/member-data';

@Component({
    selector: 'app-members-main',
    templateUrl: './members-main.component.html',
    styleUrls: ['./members-main.component.scss'],
})
export class MembersMainComponent {
    selectedMember: MemberData;
}
