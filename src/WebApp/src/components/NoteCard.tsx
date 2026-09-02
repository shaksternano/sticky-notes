export interface NoteProps {
    text: string;
    color: string;
}

export default function NoteCard(props: NoteProps) {
    return (
        <article
            class="min-h-56 rounded-2xl p-6 shadow-sm transition hover:-translate-y-1 hover:shadow-lg"
            style={{"background-color": `#${props.color}`}}
        >
            <span class="text-2xl text-white mix-blend-difference">
                ✦
            </span>
            <p class="mt-6 text-lg font-medium leading-relaxed text-white mix-blend-difference">
                {props.text}
            </p>
        </article>
    );
}
