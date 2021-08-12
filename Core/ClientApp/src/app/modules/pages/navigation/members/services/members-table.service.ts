import { Injectable } from '@angular/core';
import { SortDirection } from '@angular/material/sort';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/modules/shared/services/http.service';
import membersRoutes from '../members.routes';
import { MemberData } from '../models/member-data';

@Injectable()
export class MembersTableService {
    constructor(private readonly httpService: HttpService) {}

    getMemberDatas(sort: string, order: SortDirection, page: number): Observable<MemberData[]> {
        const params = { sort, asc: order === '' ? undefined : order === 'asc', page };
        return this.httpService.get<MemberData[]>(membersRoutes.get.members, { params });
    }
}
