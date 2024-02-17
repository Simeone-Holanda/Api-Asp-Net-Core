# Script DataBase

```
CREATE TABLE IF NOT EXISTS public.AspNetFirstApi
(
    id bigint NOT NULL DEFAULT nextval('employee_id_seq'::regclass),
    name character varying(255) COLLATE pg_catalog."default",
    age integer,
    photo character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT employee_pkey PRIMARY KEY (id)
)

```
Versão 1.1: Adicionado captura e download de imagens
* Crie uma pasta Storage dentro do seu projeto para armazenar imagens