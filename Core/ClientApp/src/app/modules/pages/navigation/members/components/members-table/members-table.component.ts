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
    readonly systemDataColumns = ['IsAdmin', 'Created', 'LastOnline'];
    readonly locationDataColumns = ['Postcode', 'City'];
    displayedColumns = ['NumberId', 'Name', 'Email', 'Sex', 'Birthdate', ...this.systemDataColumns, ...this.locationDataColumns];
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

    toggleSystemData() {
        this.toggleDatas(this.systemDataColumns);
    }

    toggleLocationData() {
        this.toggleDatas(this.locationDataColumns);
    }

    private toggleDatas(columns: string[]) {
        if (this.displayedColumns.indexOf(columns[0]) < 0) this.addColumns(columns);
        else this.removeColumns(columns);
    }

    private addColumns(columns: string[]) {
        for (const column of columns) this.displayedColumns.push(column);
    }

    private removeColumns(columns: string[]) {
        for (const column of columns) {
            const index = this.displayedColumns.indexOf(column);
            if (index >= 0) this.displayedColumns.splice(index, 1);
        }
    }
}
