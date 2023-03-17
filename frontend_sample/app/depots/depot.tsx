import Link from "next/link";

export default function Depot({ depot } : any){
    console.log(depot);
    return (
        <Link href={`/depots/${depot.id}`}>
            <div>
                <h2>{depot.name}</h2>
                <h5>{depot.owener}</h5>
                <p>{depot.location}</p>
            </div>
        </Link>
    );
}