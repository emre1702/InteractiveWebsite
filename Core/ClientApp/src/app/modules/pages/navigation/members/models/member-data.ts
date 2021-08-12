export interface MemberData {
    id: number;
    name: string;
    sex: string;
    birthdate?: Date;
    created: Date;
    lastOnline?: Date;
    postcode: number;
    isAdmin: boolean;
    email: string;
}
