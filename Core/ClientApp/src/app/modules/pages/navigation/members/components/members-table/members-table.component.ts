import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { MemberData } from '../../models/member-data';
import { MembersTableService } from '../../services/members-table.service';

@Component({
    selector: 'app-members-table',
    templateUrl: './members-table.component.html',
    styleUrls: ['./members-table.component.scss'],
})
export class MembersTableComponent implements AfterViewInit {
    displayedColumns = ['NumberId', 'Name', 'Sex', 'Birthdate', 'Created', 'LastOnline', 'Postcode', 'IsAdmin', 'Email'];
    membersList: MemberData[] = [];
    isLoadingResults: boolean;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(private readonly service: MembersTableService) {}

    ngAfterViewInit() {
        this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));

        merge(this.sort.sortChange, this.paginator.page)
            .pipe(
                startWith({}),
                tap(() => (this.isLoadingResults = true)),
                switchMap(() => this.service.getMemberDatas(this.sort.active, this.sort.direction, this.paginator.pageIndex)),
                finalize(() => (this.isLoadingResults = false)),
            )
            .subscribe((memberDatas) => (this.membersList = memberDatas));
    }
}
