import { Depot } from "@/types/depot";
import Link from "next/link";

export default function Depot({ depot } : { depot : Depot } ){
    return (
        <Link href={`/depots/${depot.id}`}>
            <div className="depot bg-blue-900 p-3 w-36 text-white hover:bg-blue-500">
                <h2>{depot.name}</h2>
                <h5>{depot.owener}</h5>
                <p>{depot.location}</p>
            </div>
        </Link>
    );
}