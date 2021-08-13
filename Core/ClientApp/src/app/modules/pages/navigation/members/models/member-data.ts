export interface MemberData {
    id: number;
    name: string;
    sex: string;
    birthdate?: Date;
    created: Date;
    lastOnline?: Date;
    isAdmin: boolean;
    email: string;
    postcode?: number;
    city?: string;
}
