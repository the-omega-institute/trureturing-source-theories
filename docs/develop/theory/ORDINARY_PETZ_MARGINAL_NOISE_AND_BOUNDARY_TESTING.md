# Ordinary Petz recovery under marginal-preserving noise and boundary testing

## 1. Scope and provenance

This volume owns the ordinary Petz recovery of a retained marginal under partial trace, its faithful regularization, and the resulting one-copy statistical experiments. The manuscript is an append-only reference input for the main trureturing repository, with generic-v1 digestion. Subsequent corrections and extensions belong after the final append anchor.

The ordinary proofs below synthesize the research manuscripts “Ordinary Petz at a singular joint reference under marginal-preserving faithful noise” and “Blind one-copy tests of the two-qubit Petz regularization” (25 November 2026). The source synchronization was implemented in an sshx worker using the first manuscript and the separately reviewed second manuscript supplied by the coordinator. Both companion exact symbolic replays were executed on the rational two-qubit data. The proofs in this volume have ordinary mathematical status. Formal coverage is recorded by the separate main-repository freezing and settlement ledger.

## 2. Setting and the accepted faithful tangent anchor

**定义 2.1（Actual recovery and deficit）。** Let $E,B$ be nonzero finite-dimensional complex Hilbert spaces, $m=\dim E$, $d=\dim B$, in factor order $E\otimes B$. Write $N=\operatorname{Tr}_E$. All traces are unnormalized, all logarithms natural, and the trace norm is full (unhalved). Let $Z,\rho$ be positive semidefinite trace-one joint matrices with $\operatorname{supp}\rho\subseteq\operatorname{supp} Z$ and $P=NZ>0$. Set $p=N\rho$. For any retained matrix $x$ define

$$
R_Z(x)=\sqrt Z(I_E\otimes P^{-1/2}xP^{-1/2})\sqrt Z,\qquad
\Delta=D(\rho\Vert Z)-D(p\Vert P),\qquad n=\|\rho-R_Z(p)\|_1.
$$

Here $D(A\Vert B)=\operatorname{Tr}A(\log A-\log B)$ on compatible supports and $+\infty$ when support containment fails, with $0\log 0=0$. Data processing gives $\Delta\ge0$. The partial trace identity gives $R_Z(P)=Z$ and $\operatorname{Tr}R_Z(x)=\operatorname{Tr}x$. The recovery formula uses the actual retained marginal $p$ of the source.

**注记 2.2（Pinned Lean anchor）。** PR 34116 merged at ec070acbd5dd7e8c5a729ebe8f8be01d063486e4. The accepted theorem D5.S3.Quantum.Recovery.PetzTangentTraceNorm.faithful_traceNorm_tangent quantifies over every nonempty finite environment index type $E$ with decidable equality, every complex matrix $H$ and every positive definite joint matrix $Z$ indexed by $\mathrm{Fin}\,2\times E$ with $\operatorname{Re}\operatorname{Tr}Z=1$. In the Lean factor order $B\otimes E$, put $P=\operatorname{partialTraceRight}Z$, $h=\operatorname{partialTraceRight}H$ and let $p_0,p_1$ be the two eigenvalues of $P$. Writing $\delta=2\sqrt{p_0p_1}$, the precise coefficient and conclusion are

$$
\begin{aligned}
\kappa(\delta)&=\begin{cases}1&\delta=1,\\ \max\{2,(3-\delta)/(1+\delta)\}&0<\delta<1,\end{cases}\\
\|H-R_Z(h)\|_1^2 &\le \kappa(\delta)
\operatorname{Re}\operatorname{Tr}\big(H^\dagger D\log_Z[H]-h^\dagger D\log_P[h]\big).
\end{aligned}
$$

The definition of $\kappa$ is parityMultiplier, with its exceptional coincident-node case. Here $D\log$ denotes the log derivative used by logDeriv, and $R_Z$ denotes partialTracePetz in Lean. Swapping the tensor factors by the permutation unitary identifies that setting with Definition 2.1. The exact merged [trace-norm theorem](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentTraceNorm.lean#L86) and [PR 34116](https://github.com/the-omega-institute/trureturing/pull/34116) supply the faithful anchor.

The proof consumes faithful_weighted_tangent, whose left side is $\sum_{ij}|(U^\dagger(H-R_Z(h))U)_{ij}|^2/((\lambda_i+\lambda_j)/2)$, for a joint diagonalizing unitary $U$ with eigenvalues $\lambda_i>0$, and whose right side is the same $\kappa$ times the BKM difference. Its entrywise physical arcsine bound uses paired_parity_bound, valid for complex $a,b,c,d$, real $g,\beta,\delta$ with $g>0$, $0<\delta\le1$, $g^2+\beta^2\le1$. Its precise inequality is

$$
|g(a+b)+\beta(c+d)|^2\le\kappa(\delta)\int_0^\infty\sqrt{1+t}
\left(\frac{|a/(1+t)+b\delta/(\delta^2+t)|^2}{2}
+\frac{|c(g+1)/(1+t)+d\delta(g+\delta)/(\delta^2+t)|^2}{2(g^2+t)}\right)dt.
$$

This gives the proof chain via [faithful_weighted_tangent and physical_entry_arcsine_and_bound](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentPhysical.lean#L720) and [paired_parity_bound](https://github.com/the-omega-institute/trureturing/blob/ec070acbd5dd7e8c5a729ebe8f8be01d063486e4/D5/S3/Quantum/Recovery/NoncommutingQubit/PetzTangentReciprocalGram.lean#L752).

## 3. Regularization with exactly preserved marginals

**定理 3.1（Finite entropy loss and quantitative recovery stability）。** For every pair of Definition 2.1 and $0\le e\le1$, put

$$
M(X)=I_E/m\otimes NX,\qquad F_e=(1-e)\mathrm{id}+e M,\qquad
Z_e=F_e(Z),\quad \rho_e=F_e(\rho).
$$

Then $NZ_e=P$, $N\rho_e=p$, and $Z_e\ge e\lambda_{\min}(P) I/m$. If $e>0$ and $p>0$, both joint states are faithful. With $Y_e=R_{Z_e}(p)$, $Y=R_Z(p)$, $n_e=\|\rho_e-Y_e\|_1$, $\Delta_e=D(\rho_e\Vert Z_e)-D(p\Vert P)$ and $K=P^{-1/2}pP^{-1/2}$, one has

$$
\begin{aligned}
0&\le\Delta_e\le (1-e)\Delta,\qquad \lim_{e\downarrow0}\Delta_e=\Delta,\\
L&=\sqrt{\operatorname{Tr}PK^2},\qquad
\|Y_e-Y\|_1\le 2L\sqrt{e\|MZ-Z\|_1},\\
|n_e-n|&\le e\|M\rho-\rho\|_1+2L\sqrt{e\|MZ-Z\|_1}
\le 2e+2\sqrt{2}L\sqrt e .
\end{aligned}
$$

The same recovery modulus holds for any two joint references $Z',Z$ with common faithful $P$ and any Hermitian retained matrix $x$, with $K=P^{-1/2}xP^{-1/2}$ and $\|Z'-Z\|_1$ in place of $e\|MZ-Z\|_1$.

Proof. The replacement map $M$ discards $E$ and prepares $I_E/m$. It is CPTP and $NM=N$. Joint convexity applies to the original supported pair and the replacement pair, for which the tensor-product logarithm gives $D(M\rho\Vert MZ)=D(p\Vert P)$. Subtracting the common output entropy proves the upper bound, and data processing proves the lower bound, also when $p$ is singular. Lower semicontinuity follows by taking the supremum over $a\downarrow0$ of $\operatorname{Tr}X\log X-\operatorname{Tr}X\log(\max(T,aI))$ for $D(X\Vert T)$ on densities. These expressions are continuous and increase to the support-aware entropy by diagonalizing $T$. Thus $\liminf\Delta_e\ge\Delta$, giving convergence.

For positive semidefinite $A,B$, set $U=\sqrt A,V=\sqrt B,D=U-V,W=\operatorname{sign}D$. Since $A-B=UD+DV$, cyclicity gives $\operatorname{Tr}W(A-B)=\operatorname{Tr}|D|(U+V)\ge\operatorname{Tr}D^2$ in an eigenbasis of $D$, using nonnegative diagonal entries of $U,V$. Trace norm duality gives $\|\sqrt A-\sqrt B\|_2^2\le\|A-B\|_1$, where $\|\cdot\|_2$ is the Hilbert–Schmidt norm. Now let $J=I_E\otimes K$, $S'=\sqrt{Z'}$, $S=\sqrt Z$. The identity $S'JS'-SJS=(S'-S)JS'+SJ(S'-S)$ and $\|JS'\|_2=\|SJ\|_2=L$ by the partial trace identity give the modulus by Schatten Hölder. Applying it to $Z_e$ and using the reverse triangle inequality for the residual yields the displayed bounds, independent of the joint rank and environment dimension except through the explicitly fixed marginal. For a density $p$, $0\le K\le\lambda_{\min}(P)^{-1}I$ and $\operatorname{Tr}PK=1$, so $L\le\lambda_{\min}(P)^{-1/2}$.

**推论 3.2（Retention of a strict finite-pair score）。** For every pair as in Definition 2.1 with $\Delta>0$ and $n^2/\Delta>c$ for a real $c\ge0$, let $\eta=n/\sqrt{\Delta}-\sqrt c>0$, $A=2+2\sqrt{2}L$. Every $0<e<1$ with $e\le\eta^2\Delta/(4A^2)$ satisfies $\Delta_e>0$ and $n_e^2/\Delta_e\ge(\sqrt c+\eta/2)^2/(1-e)>c$. For each fixed pair with positive finite loss the quotient converges to $n^2/\Delta$.

Proof. The error bound in Theorem 3.1 is at most $A\sqrt e\le\eta\sqrt\Delta/2$. Consequently $n_e\ge(\sqrt c+\eta/2)\sqrt\Delta>0$. The equality case of relative entropy data processing (Petz's equality theorem for supported pairs) implies $\Delta_e>0$. Apply the actual loss contraction and the two pointwise limits. If faithful sources are desired when $p$ is singular, mixing $\rho_e$ with $Z_e$ at a further sufficiently small positive proportion preserves a strict inequality, by continuity of entropy and the actual recovered state at fixed $e>0$. In that secondary mixture the marginal moves towards $P$.

## 4. Supported tangents and their finite-loss normalization

**定理 4.1（Transfer of the faithful tangent bound）。** For every joint reference $Z$ as in Definition 2.1, let $\Pi=\operatorname{supp}Z$, $H=H^\dagger=\Pi H\Pi$ with $\operatorname{Tr}H=0$ and $h=NH$. On the support define

$$
g_Z(H)=\int_0^\infty\operatorname{Tr}\left[H_\Pi(Z_\Pi+tI)^{-1}H_\Pi(Z_\Pi+tI)^{-1}\right]dt,\qquad G_Z(H)=g_Z(H)-g_P(h).
$$

For real sufficiently small $s$, $\rho_s=Z+sH$ is a supported density. Set $\Delta(s)=D(\rho_s\Vert Z)-D(P+sh\Vert P)$. Then

$$
\Delta(s)=\tfrac12 s^2 G_Z(H)+o(s^2),\qquad
\rho_s-R_Z(P+sh)=s(H-R_Z(h)).
$$

For $0<e\le1$, with $H_e=F_e(H)$ as in Theorem 3.1, one has $0\le G_{Z_e}(H_e)\le (1-e)G_Z(H)$ and $G_{Z_e}(H_e)\to G_Z(H)$. If $d=2$, the supported direction satisfies

$$
\|H-R_Z(h)\|_1^2\le\kappa(2\sqrt{\det P})G_Z(H).
$$

When $G_Z(H)>0$, the actual infinitesimal squared-score limit is therefore bounded by $2\kappa(2\sqrt{\det P})<6$.

Proof. On the support, $|s|\|Z_\Pi^{-1/2}H_\Pi Z_\Pi^{-1/2}\|_\infty<1$ suffices for positivity. Differentiating the trace entropy gives first derivative $\operatorname{Tr}H(\log Z_\Pi+I)$ and second derivative $\operatorname{Tr}H D\log_{Z_\Pi}[H]=g_Z(H)$ by the log resolvent formula. The output uses the same computation at faithful $P$. The first variations of both relative entropies vanish since the directions have trace zero. The residual identity follows from linearity. Apply the finite-loss contraction to $(Z+sH,Z)$, whose regularized source is $Z_e+sH_e$ with unchanged output. Divide by $s^2/2$ and let $s\to0$ for fixed $e$.

For energy convergence, $Z_e\ge(1-e)Z$ implies $\Pi(Z_e+tI)^{-1}\Pi\le((1-e)Z_\Pi+tI)^{-1}$ for $t>0$. For $e\le1/2$ the integrand with $H$ is dominated by $\|H\|_2^2/(\lambda_{\min}(Z_\Pi)/2+t)^2$ and converges by continuity of the inverse. The energy of $eMH$ is bounded by $e^2\|MH\|_2^2/(e\lambda_{\min}(P)/m)=O(e)$, and the mixed term by the BKM Cauchy–Schwarz inequality. Thus $g_{Z_e}(H_e)\to g_Z(H)$. Apply the accepted faithful theorem from Note 2.2 to $(Z_e,H_e)$ at the identical $P$. The Hermitian-direction recovery modulus in Theorem 3.1 and $H_e\to H$ allow passage to the limit. If $G_Z(H)=0$ the resulting residual vanishes. Otherwise the expansion yields the factor of two in the infinitesimal quotient. In particular the positive-marginal restriction is retained even for singular joint references.

## 5. Sharp regularity at a support boundary

**定理 5.1（Support/kernel crossing for arbitrary fixed faithful reference noise）。** Keep $Z,P$ as above, let $Q=I-\Pi$, and take any fixed faithful joint density $\tau>0$ with $N\tau=P$. For $0\le e\le1$ let $Z_e=(1-e)Z+e\tau$. For every Hermitian retained matrix $x$, set $J=I_E\otimes P^{-1/2}xP^{-1/2}$ and $T=Q\sqrt{(Q\tau Q)|_Q}Q$, extended by zero on $\Pi$ (zero if $Q=0$). Then in every fixed finite matrix norm

$$
\begin{aligned}
\sqrt{Z_e}&=\sqrt Z+\sqrt e\,T+O(e),\\
R_{Z_e}(x)-R_Z(x)&=\sqrt e\,(TJ\sqrt Z+\sqrt ZJT)+O(e),\\
\lim_{e\downarrow0}\frac{\|R_{Z_e}(x)-R_Z(x)\|_1}{\sqrt e}&=2\|TJ\sqrt Z\|_1 .
\end{aligned}
$$

The coefficient is positive exactly when $QJ\Pi\ne0$, equivalently $[J,\Pi]\ne0$. In that case the change has order $\Theta(\sqrt e)$, and in the zero-coefficient case it is $O(e)$. If $x>0$ and $Q\ne0$, the zero-coefficient case has order $\Theta(e)$.

Proof. Write the positive square root in support/kernel blocks as

$$
\sqrt{Z_e}=\begin{pmatrix}A_e&B_e\\B_e^\dagger&C_e\end{pmatrix},\qquad S_0=\sqrt{Z_\Pi}.
$$

The root modulus proves convergence to $S_0\oplus0$. Hence for sufficiently small $e$, $A_e\ge aI$ for some fixed $a>0$, and $C_e\ge0$. The off-diagonal equation obtained by squaring is $A_e B_e+B_e C_e=e\tau_{\Pi Q}$. The Sylvester map is invertible, because in separate eigenbases every coordinate is multiplied by an eigenvalue sum at least $a$. Its Hilbert–Schmidt inverse bound gives $B_e=O(e)$. The top equation gives $A_e^2-S_0^2=e(\tau_{\Pi\Pi}-Z_\Pi)-B_eB_e^\dagger=O(e)$. Apply the same argument to $A_e(A_e-S_0)+(A_e-S_0)S_0$ to get $A_e-S_0=O(e)$. The bottom equation $C_e^2=e\tau_{QQ}-B_e^\dagger B_e$ implies $(C_e/\sqrt e)^2=\tau_{QQ}+O(e)$. The Sylvester map with second factor $\sqrt{\tau_{QQ}}>0$ gives $C_e/\sqrt e=\sqrt{\tau_{QQ}}+O(e)$. When $Q=0$ only the top equation is needed.

The resulting root expansion gives the recovery expansion by multiplication. Its leading coefficient is Hermitian off-diagonal with trace norm $2\|TJ\sqrt Z\|_1$, by the paired positive and negative singular values of the off-diagonal blocks. The restrictions of $T$ to $Q$ and $\sqrt Z$ to $\Pi$ are invertible, proving the crossing equivalence. For $J>0$ the new recovery has $Q$-block trace $e\operatorname{Tr}(TJT)+O(e^{3/2})$ from these block estimates, with positive coefficient if $Q\ne0$. The old $Q$ block vanishes, giving the claimed lower bound by trace duality.

For the product noise of Theorem 3.1, $\rho_e-\rho=O(e)$, so the residual $\rho_e-R_{Z_e}(p)$ changes with the negative of the same leading coefficient. In the tangent family $Z+sH$ the exact identities $F_e(Z)=Z_e=R_{Z_e}(P)$ give a remainder $O(|s|e)$ after expanding the recovery of $h=NH$. These are pointwise fixed-reference boundary expansions. The uniform weighted modulus of Theorem 3.1 uses only the common marginal.

## 6. A rational two-qubit family and a fixed measurement

**命题 6.1（An actual sharp crossing at a fixed marginal）。** Take $E=B=\mathbb C^2$ and order the orthonormal basis as $(00,+,-,11)$ with $\psi_\pm=(01\pm10)/\sqrt2$ and $P_v=|v\rangle\langle v|$. Use

$$
\begin{aligned}
Z&=(P_{00}+P_+)/2,\quad H=P_+-P_{00},\quad \rho_s=Z+sH,\quad -1/2\le s\le1/2,\\
P&=\operatorname{diag}(3/4,1/4),\quad h=\operatorname{diag}(-1/2,1/2),\quad p_s=P+sh .
\end{aligned}
$$

The input matrices have rational computational-basis entries for rational $s$. For the product regularization and $Y_{s,e}=R_{Z_e}(p_s)$,

$$
\lim_{e\downarrow0}\|Y_{s,e}-Y_{s,0}\|_1/\sqrt e=(2\sqrt2/3)|s|.
$$

In particular the exponent $1/2$ is sharp at fixed $P$ and dimension four. On the same family $G_Z(H)=8/3$, $\Delta(s)=4s^2/3+o(s^2)$ and $\|H-R_Z(h)\|_1=4/3$.

Proof. Partial traces give the displayed $P,h$. On $\Pi=\operatorname{span}(00,+)$ the two weights of $\rho_s$ are $1/2-s,1/2+s$. Hence $g_Z(H)=4$ and $g_P(h)=(4/3+4)/4=4/3$. The tangent recovery on $\Pi$ is diagonal with entries $-1/3,1/3$. In the $(+,-)$ block the lifted likelihood $J_s=I_E\otimes P^{-1/2}p_sP^{-1/2}$ has off-diagonal entry $4s/3$. On the kernel, the compression of $\tau=I_E/2\otimes P$ is $\operatorname{diag}(1/4,1/8)$, so $TJ_s\sqrt Z=(2s/(3\sqrt2))|-\rangle\langle+|$. Theorem 5.1 gives the limit, and Theorem 4.1 gives the entropy expansion.

**定理 6.2（Fixed binary POVM and critical copy limit）。** On the same family let $W=|+\rangle\langle-|+|-\rangle\langle+|$ extended by zero, and measure the fixed POVM $\{(I+W)/2,(I-W)/2\}$ independently on each copy of the two joint hypotheses $\rho_{s,e}=F_e(\rho_s)$ and $Y_{s,e}$. For every sequence $e=e_N\in(0,1]$ tending to zero and $s=s_N\in[-1/2,1/2]$, with $N s_N^2 e_N\to\ell\in[0,\infty]$, the optimal equal-prior average measured error and optimal maximum conditional measured error converge to

$$
\Phi(-\sqrt{2\ell}/3)
$$

with $\Phi$ the standard normal CDF and the value zero at $\ell=\infty$.

Proof. The effects are positive and sum to $I$, as $\|W\|_\infty=1$. The middle block of $Z_e$ and its positive square root are

$$
M_e=\begin{pmatrix}1/2-e/4&-e/8\\-e/8&e/4\end{pmatrix},\qquad
d_e=\sqrt{e(8-5e)}/8,\qquad
\sqrt{M_e}=\begin{pmatrix}A&B\\B&C\end{pmatrix}=(M_e+d_e I)/\sqrt{1/2+2d_e}.
$$

The square identity follows from Cayley–Hamilton with $\operatorname{Tr}M_e=1/2$ and $\det M_e=d_e^2$, and positivity selects the root. In particular $AC-B^2=d_e$ and $B=-e/(8\sqrt{1/2+2d_e})$. Write $J=I_E\otimes P^{-1/2}hP^{-1/2}$. Its middle block is $(2/3)I+(4/3)W$. The reference cancels exactly from the difference $Y_{s,e}-\rho_{s,e}=s(R_{Z_e}(h)-H_e)$, and the off-diagonal entry of $H_e$ is $e/4$. The first effect has outcome probability $1/2$ plus the middle off-diagonal entry on these real densities. Multiplying the root blocks therefore gives the two first-outcome probabilities $u,v$ exactly,

$$
u=1/2-e/8+se/4,\qquad v-u=sf(e),\qquad f(e)=-e/3+(4/3)d_e+(8/3)B^2=(\sqrt2/3)\sqrt e+O(e).
$$

Thus $u,v\to1/2$ uniformly in the physical $s$ interval. Put $b_N=v-u$. For $0<\ell<\infty$, $I_N=Nb_N^2/[u(1-u)]\to I=8\ell/9$. The one-copy log likelihood of $v$ against $u$ takes values $\log(1+b_N/u)$ and $\log(1-b_N/(1-u))$. Taylor expansion gives means under the two hypotheses respectively $-b_N^2/(2u(1-u))+O(|b_N|^3)$ and $+b_N^2/(2u(1-u))+O(|b_N|^3)$, and variances $b_N^2/(u(1-u))+O(|b_N|^3)$. The remainders sum to zero in the limit and the centered increments are uniformly $O(|b_N|)$. The triangular-array Lindeberg theorem gives log likelihood limits $N(-I/2,I)$ and $N(I/2,I)$ (normal laws). The zero threshold likelihood test minimizes the equal-prior average error, and both conditional errors tend to $\Phi(-\sqrt I/2)$. The maximum conditional error is at least the optimal average error, yielding the same minimax limit. For $\ell=0$, the Bernoulli relative entropy is $O(b_N^2)$, so additivity and Pinsker give product total variation tending to zero. Random guessing attains the limit $1/2$ for both criteria. For $\ell=\infty$, the empirical mean threshold $(u+v)/2$ oriented by the sign of $v-u$ has both errors at most $1/(Nb_N^2)$ by Chebyshev. These proofs allow changing signs and vanishing perturbations.

## 7. Fixed versus noise-dependent blind measurements

**定理 7.1（Sharp repeated blind POVM constants）。** Use exactly the hypotheses of Theorem 6.2. A one-copy POVM is blind if it gives equal laws at $e=0$ for every physical $s$. Consider sequences with $s=s_N\to0$, $e=e_N\downarrow0$, and $Ns_N^2e_N\to\ell\in[0,\infty]$. Among all fixed finite blind POVMs repeated independently, the best limiting equal-prior and maximum conditional errors are $\Phi(-\sqrt{2\ell}/3)$. Among sequences of finite blind POVMs (arbitrary finite outcome counts) that may depend on $s,e,N$ and are repeated independently within each experiment, the sharp limits of the infima of these errors are $\Phi(-\sqrt\ell/2)$. A binary POVM depending only on $e$ attains the second limit. The constants are strictly distinct for $0<\ell<\infty$.

Proof. At $e=0$, $R_Z(h)-H=(2/3)(P_{00}-P_+)$. Consequently blindness is exactly equality of the $00$ and $++$ diagonals of every effect. Write an arbitrary effect's diagonal as $(a,a,b,c)$ and $z=\operatorname{Re}E_{+,-}$. Positivity and completeness give $|z|\le\sqrt{ab}$, $\sum a=\sum b=\sum c=1$ and $\sum z=0$. For each effect, write $p=\operatorname{Tr}E Z_e$, $g=\operatorname{Tr}E H_e$, and $d=\operatorname{Tr}E(R_{Z_e}(h)-H_e)$. From the matrices in Theorem 6.2 the two exact laws are $q=p+sg$, $r=q+sd$, where

$$
\begin{aligned}
p&=(1-3e/8)a+eb/4+ec/8-ez/4,&g&=e(c-a)/4+ez/2,\\
d&=\beta_e(b-a)+2f(e)z,&\beta_e&=e/6+(8/3)BC .
\end{aligned}
$$

Indeed the $--$ diagonal of the recovery derivative minus $H_e$ is $(2/3)(e/4)+(8/3)BC$, the $11$ entry is zero, and the trace is zero. The off-diagonal is $f(e)$ from Theorem 6.2. Here $B=O(e), C=O(\sqrt e)$, using its root block. In particular, with $k=2\sqrt2/3$,

$$
d=d_0+R,\qquad d_0=k\sqrt e\,z+eb/6,\qquad |R|\le C_0(ea+e^{3/2}(b+c)+e\sqrt{ab}).
$$

Let $p_*=a+eb/4+ec/8$. Rows with $p_*=0$ for $e>0$ are zero effects and can be omitted. By $|z|\le\sqrt{ab}$ and $\sqrt{eab}\le a+eb/4$, one has $q/p_*=1+O(\sqrt e+|s|)$, $|g|/p_*=O(1)$ and $|d|/q=O(1)$ uniformly for sufficiently small $e,|s|$. Squaring the remainder with the factor three bound and using $a^2/p_*\le a$, $(b+c)^2/p_*\le8(b+c)/e$, $ab/p_*\le b$ gives $\sum R^2/p_*=O(e^2)$. Weighted Cauchy–Schwarz gives

$$
|d_0|/\sqrt e\le\sqrt b(k\sqrt a+\tfrac13\sqrt{eb/4}),\qquad
d_0^2/(ep_*)\le b(k^2+1/9)=b.
$$

Thus, using Cauchy–Schwarz also on the mixed remainder, the squared score norm $J_{s,e}=\sum d^2/q$ obeys uniformly over all finite blind POVMs

$$
J_{s,e}/e=\sum d_0^2/(ep_*)+O(\sqrt e+|s|)\le1+O(\sqrt e+|s|).
$$

In a fixed finite POVM, rows with $a>0$ contribute $k^2z^2/a\le(8/9)b$ in the limit. Rows with $a=0$ have $z=0$ and contribute $(b/6)^2/(b/4+c/8)\le b/9$. Hence

$$
J_{s,e}/e\longrightarrow I(M)=k^2\sum_{a>0}z^2/a+\sum_{a=0}\frac{(b/6)^2}{b/4+c/8}\le8/9,
$$

with the zero row interpreted as zero. The fixed effects $(I\pm W)/2$ attain $8/9$ since both have $a=b=c=1/2$ and $z=\pm1/2$.

For the moving test, choose $\theta\in(0,\pi/2)$ with $\tan^2\theta=2e$, $v=\cos\theta\,\psi_-+\sin\theta\,\psi_+$. The effect $E=P_v+\sin^2\theta\,P_{00}$ and its complement form a blind POVM, since the two projectors in $E$ have orthogonal supports. For $E$, $(a,b,c,z)=(2e,1,0,\sqrt{2e})/(1+2e)$. The rare outcome has $q\sim9e/4$ and $d\sim3e/2$, by the exact formulas and $s\to0$. Its complement has $q\to1$ and opposite $d$. Hence $J_{s,e}/e\to1$.

For any sequence of repeated blind POVMs the relative increment $\zeta=sd/q$ under the source law has mean zero, variance $V=s^2J_{s,e}$ and $|\zeta|=O(|s|)$ uniformly. The log likelihood increment $\log(1+\zeta)$ has mean $-V/2+O(|s|V)$, second moment $V+O(|s|V)$ and third absolute moment $O(|s|V)$. Under the recovery law, weighting each expectation by $1+\zeta$ changes the mean to $V/2+O(|s|V)$ and preserves the second moment estimate. For a subsequence with $J_{s,e}/e\to I$ and finite $\ell$, the summed log likelihood converges under the two hypotheses to normal laws with means $\mp\ell I/2$ and variance $\ell I$ when $\ell I>0$, by Lindeberg and the uniform vanishing increment bound. If $\ell I=0$, the source log likelihood tends to zero in probability from its mean and variance. The optimal average error is $\tfrac12\mathbb E_q\min(1,\exp L_N)$, where $L_N$ is the summed log likelihood, so bounded continuity gives $\Phi(-\sqrt{\ell I}/2)$ in both cases. When $\ell I>0$ the two conditional threshold errors have that limit, and for $\ell I=0$ random guessing suffices for the maximum conditional criterion. Every sequence has such subsequences because the coefficients $J_{s,e}/e$ are bounded, with all accumulation points at most one (and at most $8/9$ for each fixed finite POVM). This proves the lower bounds including for a sequence approaching the infima. The displayed attaining POVMs give the matching limits. For $\ell=\infty$ and either attaining POVM, the repeated score $d/q$ has source mean zero and variance $J_{s,e}$, recovery mean $sJ_{s,e}$ and variance at most $(1+O(|s|))J_{s,e}$. The mean-score threshold $sJ_{s,e}/2$, oriented by the sign of $s$, has conditional errors $O(1/(Ns^2J_{s,e}))\to0$. This finishes both endpoint cases as well.

## 8. Outstanding global problem and sources

**开放问题 8.1（The ordinary finite-displacement constant）。** For retained qubit dimension define $C(2)$ as the supremum of $\|\rho-R_Z(p)\|_1^2/\Delta$ over the supported pairs of Definition 2.1 with $\Delta>0$, allowing every finite nonzero environment dimension. The same supremum describes all finite CPTP maps $\mathcal N$ with output reference rank two, using the inverse on that output support and ordinary recovery $\sqrt Z\,\mathcal N^\dagger((\mathcal NZ)^{-1/2}(\mathcal N\rho)(\mathcal NZ)^{-1/2})\sqrt Z$. Indeed a Stinespring isometry $V$ with $\mathcal N(X)=\operatorname{Tr}_E(VXV^\dagger)$ sends the input support into $E\otimes\operatorname{supp}(\mathcal NZ)$: the expectation of the complementary output projection in $VZV^\dagger$ is zero. It preserves both relative entropies, and the joint recovery is exactly the isometric image of the original recovery by $V^\dagger(I_E\otimes A)V=\mathcal N^\dagger(A)$. Thus it preserves the full trace norm of the residual. Partial traces are themselves CPTP, giving equality of the two suprema. The ordinary assertion $C(2)=6$ remains open. Theorem 3.1 and Corollary 3.2 reduce a strict finite-pair violation to faithful references, preserving the individual marginals in the first regularization. Theorem 4.1 bounds the common-reference infinitesimal quotient. Establishing a global sharp finite-displacement bound would require controlling the actual recovery and entropy along finite displacements, including unbounded environment dimensions. The boundary experiment of Sections 6–7 quantifies a different observable, the blind measured decision error for one fixed physical family.

The literature inputs used in the proofs are joint convexity and data processing of quantum relative entropy, Petz's equality theorem, Schatten Hölder, the resolvent identity for the log derivative, and the Lindeberg central limit theorem. The fixed-marginal identities, boundary expansions, and measured asymptotics are repo-derived ordinary proofs. The two independent symbolic replays checked the partial traces, root square identity, signed recovery entries, crossing coefficient, BKM coefficient and binary Fisher limits $8/9$ and $1$. The quantification over arbitrary finite matrix sizes and the statistical limits follow from the proofs. Formal acceptance of the faithful theorem and its consumers is pinned in Note 2.2.

## 追加锚（本行以下为增补区）

## 9. Weighted environment truncation and finite-copy testing

This supplement extends the finite-displacement problem in Section 8 by comparing actual ordinary Petz outputs under a specified environment compression and by exhibiting its two-qubit obstruction.

**定理 9.1（Weighted kept-block Sylvester transport）。** Let $\rho,\sigma$ be joint densities on finite nonzero $E\otimes B$ with $\operatorname{supp}\rho\subseteq\operatorname{supp}\sigma$. In this section write $T=\operatorname{Tr}_E$, $P=T\rho$, $Q=T\sigma$, $L=Q^{-1/2}PQ^{-1/2}$ and $M=I_E\otimes L$. Restrict $B$ to $\operatorname{supp}Q$, so $Q>0$. The actual recovered density is $Y=\sqrt\sigma M\sqrt\sigma$. For any orthogonal projection $J$ on $E$ and $K=I_E-J$, use their lifts by $I_B$ and the channel $\Phi$ to $JE\oplus\mathbb C f$ given by

$$
\Phi(W)=JWJ\oplus\operatorname{Tr}_{KE}(KWK).
$$

Put $\rho'=\Phi(\rho)$, $\sigma'=\Phi(\sigma)$ and let $Y'$ be the ordinary Petz output from $\sigma'$ and the actual retained marginal of $\rho'$. Write $r=\|\rho-Y\|_1$, $r'=\|\rho'-Y'\|_1$ and the actual deficits $\Delta=D(\rho\Vert\sigma)-D(P\Vert Q)$ and $\Delta'=D(\rho'\Vert\sigma')-D(P\Vert Q)$. Use the common environment $JE\oplus KE\oplus\mathbb C f$, extending the respective states by zero. In the original two blocks write

$$
S=\sqrt\sigma=\begin{pmatrix}H&G\\G^\dagger&C\end{pmatrix},\quad
D=\sqrt{H^2+GG^\dagger},\quad F=\sqrt{\operatorname{Tr}_{KE}(C^2+G^\dagger G)},\quad X=D-H.
$$

Use $A_J=I_{JE}\otimes\sqrt L$, $A_K=I_{KE}\otimes\sqrt L$, $A_f=\sqrt L$, with $\sqrt M$ lifted to the common space. Define $x=\|XA_J\|_2$, $t=\operatorname{Tr}(MK\sigma)$, $b=\|G^\dagger A_J\|_2^2$, and $a=\|S\sqrt M-\sqrt{\sigma'}\sqrt M\|_2$ in that space. Then

$$
\begin{aligned}
a^2&=x^2+2t+b,&\|Y-Y'\|_1&\le\min(2,2a),\\
DX+XH&=GG^\dagger,&HX+XH+X^2&=GG^\dagger,\\
XA_J&=\int_0^\infty e^{-sD}GG^\dagger e^{-sH}A_J\,ds .
\end{aligned}
$$

These identities include singular kept blocks. Writing $V=XA_J$, its weighted Sylvester equation is $DV+VH=GG^\dagger A_J+X[A_J,H]$. For $c=\|[A_J,H]\|_2$, $\kappa=\|L\|_\infty$ and $w_\sigma=\operatorname{Tr}(K\sigma)$, one has

$$
x\le c/\sqrt2+\sqrt{b+c^2/2},\qquad x^2\le\kappa\|G\|_2^2,\qquad a^2\le4\kappa w_\sigma.
$$

Proof. Support containment implies $\rho\le c_0\sigma$ for some finite $c_0$, so both retained marginals are supported on $Q$ and $\rho'\le c_0\sigma'$. The environment Kraus operators of $\Phi$ are the kept inclusion composed with $J$ and the operators $|f\rangle\langle k|$ for an orthonormal basis of $KE$. Their adjoint products sum to $I_E$. Summing the two diagonal environment marginals preserves $P,Q$ exactly, so the likelihood $L$ is common. The compressed square root is $D\oplus0\oplus F$ on the common space. The amplitudes $U=S\sqrt M$ and $U'=\sqrt{\sigma'}\sqrt M$ give $Y=UU^\dagger$, $Y'=U'U'^\dagger$, both with squared Hilbert–Schmidt norm of the amplitude equal to $\operatorname{Tr}(LQ)=1$. The discarded column contributes $t=\|GA_K\|_2^2+\|CA_K\|_2^2$, the off-diagonal discarded row contributes $b$, and the flag contributes $\|FA_f\|_2^2=t$. The full discarded row weight is $\operatorname{Tr}(KY)=b+\|CA_K\|_2^2$. Including the kept block gives the stated squared amplitude identity. Factoring the difference of the two amplitude products and using Schatten Hölder gives the trace bound.

Square-root monotonicity gives $D\ge H\ge0$. Expand $D^2-H^2=GG^\dagger$ to obtain the two Sylvester identities. In separate eigenbases for $D,H$, the coefficient of the first Sylvester map is $d+h$ for eigenvalues $d,h\ge0$. At $d=h=0$ the corresponding block of $X$ vanishes since $\ker D\subseteq\ker H$ and $X$ annihilates $\ker D$. Integration of $e^{-s(d+h)}$ on the positive-sum blocks proves the formula. Multiplying the first identity by $A_J$ on the right and commuting $A_J$ across $H$ gives the weighted equation.

For the estimates let $A=A_J$. Taking the trace of the quadratic identity against $A^2$ and expanding the double commutator gives

$$
x^2=b-2\operatorname{Tr}(XAHA)-\operatorname{Tr}([X,A][A,H]).
$$

The middle trace is nonnegative. Since $X,A\ge0$, the trace $\operatorname{Tr}(AXAX)$ is nonnegative and $\|[X,A]\|_2^2=2x^2-2\operatorname{Tr}(AXAX)\le2x^2$. Cauchy–Schwarz gives $x^2\le b+\sqrt2 cx$ and solving the quadratic yields the first estimate. The unweighted trace gives $\|X\|_2^2\le\|G\|_2^2$. Also $t\le\kappa w_\sigma$ and $b\le\kappa\|G\|_2^2\le\kappa w_\sigma$ because the discarded diagonal block of $\sigma$ is $C^2+G^\dagger G$. Substituting into the amplitude identity gives the final estimate.

**命题 9.2（Vanishing weighted tails with a strict change of actual recovery）。** There is a supported two-qubit pair with joint reference of rank three and $Q\ge(3/16)I$, and with the compressor of Theorem 9.1, for which $t=b=w_\rho=0$ with $w_\rho=\operatorname{Tr}(K\rho)$. Nevertheless $x>0$, $\Phi(Y)=Y$ under the common embedding, and $Y'\ne Y$. Its actual residual decreases strictly under the compression. There is a family of faithful joint pairs approaching this example through the same compressor, with $t,b,w_\rho=O(\epsilon^2)$ and $Q_\epsilon\ge(3/32)I$ for $0<\epsilon<1$, for which the recovery gap tends to a positive value. Both original and compressed entropy defects are positive in the limit and their squared scores are below one.

Proof. Take $E=B=\mathbb C^2$, with $J=|0\rangle\langle0|$ on $E$ and retained coordinates $e_0,e_1$. Set

$$
H_0=\begin{pmatrix}2&1\\1&2\end{pmatrix},\quad
G_0=\operatorname{diag}(0,1),\quad C_0=\operatorname{diag}(0,2),\quad
S_0=\begin{pmatrix}H_0&G_0\\G_0&C_0\end{pmatrix},\quad \sigma=S_0^2/16.
$$

The kernel of $S_0$ is spanned by $|1\rangle\otimes e_0$. On the complementary coordinates $(00,01,11)$ it is tridiagonal with diagonal $2$ and adjacent entries $1$, hence has eigenvalues $2+\sqrt2,2,2-\sqrt2$. Thus $\sqrt\sigma=S_0/4$ and $\operatorname{Tr}\sigma=1$. The kept block of $S_0^2$ is $A_0=\begin{pmatrix}5&4\\4&6\end{pmatrix}$, the discarded block is $\operatorname{diag}(0,5)$, and $Q=Q_0/16$ with $Q_0=\begin{pmatrix}5&4\\4&11\end{pmatrix}$ of eigenvalues $13,3$. For a unit vector $z$ write $P_z=|z\rangle\langle z|$. Put $v=\sqrt{Q_0}e_0/\sqrt5$ and $\rho=P_{|0\rangle\otimes v}$. It is supported in $\sigma$ and $P=P_v$, $L=(16/5)P_{e_0}$. Both weighted tails vanish since $G_0,G_0^\dagger,C_0$ annihilate $e_0$. The two recovered states have kept unit vectors $h=H_0 e_0/\sqrt5$ and $d=\sqrt{A_0}e_0/\sqrt5$. If $Xe_0=0$, Hermiticity gives $X=\operatorname{diag}(0,u_0)$ and the $01$ coordinate of $HX+XH+X^2=GG^\dagger$ forces $u_0=0$ since $H_{01}=1/4$. This contradicts $GG^\dagger\ne0$.

For any positive definite two-by-two matrix $A$, Cayley–Hamilton verifies $\sqrt A=(A+\sqrt{\det A}I)/\sqrt{\operatorname{Tr} A+2\sqrt{\det A}}$. Consequently the respective slopes of $v,h,d$ are $\alpha,1/2,\beta$, where

$$
\alpha=4/(5+\sqrt{39}),\qquad \beta=4/(5+\sqrt{14}),\qquad 0<\alpha<\beta<1/2.
$$

Two real unit vectors of slopes $u,v_1$ and positive first coordinates have pure-state trace distance $R(u,v_1)=2|u-v_1|/\sqrt{(1+u^2)(1+v_1^2)}$, by diagonalizing the difference on their span. Increasing the angle $\arctan s-\arctan\alpha$ for $\alpha<s\le1/2$ proves $r=R(\alpha,1/2)>r'=R(\alpha,\beta)$. The actual output gap is $R(\beta,1/2)$ and $x^2=2-2(1+\beta/2)/\sqrt{(1+1/4)(1+\beta^2)}$.

For the exact defects set $u=(1+\alpha^2)^{-1/2}$, $v_1=\alpha u$, $k_\pm=(11\pm\sqrt{65})/2$, and $p_*=(5u^2+8uv_1+6v_1^2-k_-)/(k_+-k_-)$. The log expectations at the pure vector are

$$
\begin{aligned}
m&=(13\log13+12\log3)/25,\\
s&=(u/2+v_1/\sqrt2)^2\log((2+\sqrt2)^2)+(u^2/2)\log4
 +(u/2-v_1/\sqrt2)^2\log((2-\sqrt2)^2),\\
s'&=p_*\log k_++(1-p_*)\log k_- .
\end{aligned}
$$

Indeed the $e_0$ weights on the eigenspaces of $Q_0$ are $1/5,4/5$, which become $13/25,12/25$ in $v$. The three reference weights are the squared overlaps with $(1/2,\pm1/\sqrt2,1/2)$ and $(1/\sqrt2,0,-1/\sqrt2)$, and $p_*$ is the $k_+$ weight for $A_0$. Purity cancels the source entropies and the normalization logarithms cancel between the reference and its marginal. Thus $\Delta=m-s$ and $\Delta'=m-s'$. The pinned directed interval replay of these exact expressions gives

$$
\begin{aligned}
r&\in(0.2431802107,0.2431802108),&r'&\in(0.1745435495,0.1745435496),\\
r-r'&\in(0.0686366611,0.0686366612),&\|Y-Y'\|_1&\in(0.0690038604,0.0690038605),\\
\Delta&\in(0.0731558158,0.0731558159),&\Delta'&\in(0.0455696576,0.0455696577),\\
r^2/\Delta&\in(0.8083651886,0.8083651888),&r'^2/\Delta'&\in(0.6685468418,0.6685468419),\\
x^2&\in(0.0011907376,0.0011907377).
\end{aligned}
$$

For faithful approximation let $z_\epsilon^2=\|S_0+\epsilon I\|_2^2=16+12\epsilon+4\epsilon^2$, $\sigma_\epsilon=(S_0+\epsilon I)^2/z_\epsilon^2$, $Q_\epsilon=T\sigma_\epsilon$, $v_\epsilon=\sqrt{Q_\epsilon}e_0/\sqrt{(Q_\epsilon)_{00}}$, and $\delta=\epsilon^2$. Put $\rho_\epsilon=(1-\delta)P_{|0\rangle\otimes v_\epsilon}+\delta\sigma_\epsilon$. Both states are faithful for $0<\epsilon<1$. Their actual likelihood is $(1-\delta)P_{e_0}/(Q_\epsilon)_{00}+\delta I$. In particular $Q_\epsilon\ge Q_0/z_\epsilon^2\ge(3/32)I$, with least eigenvalue tending to $3/16$. Substitution gives

$$
\begin{aligned}
w_{\sigma,\epsilon}&=(5+4\epsilon+2\epsilon^2)/z_\epsilon^2,& w_{\rho,\epsilon}&=\delta w_{\sigma,\epsilon},\\
t_\epsilon&=(1-\delta)\epsilon^2/(5+4\epsilon+2\epsilon^2)+\delta w_{\sigma,\epsilon},&
b_\epsilon&=\delta/z_\epsilon^2.
\end{aligned}
$$

The compressor preserves the two retained marginals for each $\epsilon$, and these marginals may vary with $\epsilon$. Continuity of square roots and the retained inverse gives convergence of the recoveries and residuals. In the logarithm expectation the pure source component lies in the fixed positive spectral subspace of $S_0$, where the reference logarithms converge, and in the uniformly positive kept block after compression. The reference-mixture term contributes $\delta\operatorname{Tr}(\sigma_\epsilon\log\sigma_\epsilon)$ and its compressed counterpart, both tending to zero. Source entropies and retained terms are continuous. Hence both defects and both squared scores converge. This family rules out a modulus tending to zero in the weighted tails $t,b$ even with $w_\rho$ included, at the stated dimensions and marginal floor, for this compressor.

**定理 9.3（Same-copy simulation and strict Bayes gap）。** Under Theorem 9.1 let $N\ge1$ be any finite integer. Define the decoder from $JE\oplus\mathbb C f$ to $E$ by keeping the kept block and replacing the flag by a fixed density on $KE$ while retaining its retained-system marginal. If $K=0$, decode the unused flag to any fixed environment density. The prescribed product channels $\Phi^{\otimes N}$ and the product decoder compare the triples $(\rho^{\otimes N},\sigma^{\otimes N},Y^{\otimes N})$ and $((\rho')^{\otimes N},(\sigma')^{\otimes N},(Y')^{\otimes N})$ with worst per-hypothesis unhalved trace error in either direction bounded by

$$
\min\big(2,\,2\sqrt{N\max(2w_\rho,2w_\sigma,a^2)}\big).\tag{9.1}
$$

For the binary experiment $(\rho,Y)$ use $\max(2w_\rho,a^2)$ in this expression. These are bounds for the specified product maps, hence also upper bounds for the respective optimal errors when the processing is optimized over all CPTP maps. Each collective POVM event has simulation error at most half the corresponding trace error.

In Proposition 9.2 the equal-prior optimal Bayes error strictly increases for every finite $N\ge1$. Writing

$$
r_N=2\sqrt{1-|\langle v,h\rangle|^{2N}},\qquad
r'_N=2\sqrt{1-|\langle v,d\rangle|^{2N}},
$$

the increase is $(r_N-r'_N)/4>0$. Every reverse CPTP simulation of this binary pair has maximum per-hypothesis unhalved trace error at least $(r_N-r'_N)/2$. The prescribed forward compressor has exact benchmark error $2\sqrt{1-|\langle h,d\rangle|^{2N}}$. For each fixed $N$, the strict Bayes gap persists for sufficiently small positive $\epsilon$ in the faithful family of Proposition 9.2.

Proof. Write $f(A,B)=\|\sqrt A\sqrt B\|_1$ for root fidelity. For $W=\rho,\sigma$ the compressed and decoded densities both dominate $JWJ$ in the relevant common embedding. Since $\sqrt W JWJ\sqrt W=(\sqrt W J\sqrt W)^2$, monotonicity of the square root gives root fidelity at least $1-w_W$ with $W$. The source and reference forward simulations are exact. For the actual benchmarks the normalized amplitudes of Theorem 9.1 have real Hilbert–Schmidt overlap $1-a^2/2$. Vectorizing them gives purifications, so $f(Y,Y')\ge g=(1-a^2/2)_+$. The common-space extensions of the compressor and decoder dephase between $E$ and the flag, then respectively fix the flag and fix $E$. They therefore fix the corresponding embedded target states. Contractivity bounds the benchmark errors in both directions by the common-space distance of the tensor powers. Multiplicativity of root fidelity and the fidelity–trace inequality yield the reverse source and reference bounds $2\sqrt{1-(1-w_W)^{2N}}$ and the two benchmark bounds $2\sqrt{1-g^{2N}}$. Using $1-(1-u)^N\le Nu$ for $0\le u\le1$ gives (9.1), with the trivial upper bound $2$. The event estimate follows from trace duality for effects. At bounded $N\Delta$, the binary error bound tends to zero along any family with positive $\Delta$ and $w_\rho+a^2=o(\Delta)$.

For the example the angle order from Proposition 9.2 gives $0<|\langle v,h\rangle|<|\langle v,d\rangle|<1$. The pure-state trace formula and tensor-product overlaps give $r_N>r'_N$ for every finite $N\ge1$. By the Helstrom formula the two optimal equal-prior errors are $1/2-r_N/4$ and $1/2-r'_N/4$. If a reverse CPTP map has maximum per-hypothesis trace error $q$, then trace contractivity and the triangle inequality imply $r_N\le r'_N+2q$. The forward formula follows because the specified compressor fixes both kept pure densities. At each fixed copy number continuity of the tensor-product densities and trace norms gives the strict faithful gap.

### 9.4 Sources and scope

The three results are repo-derived ordinary proofs from “Weighted ordinary Petz comparison for a projection and external flag” (25 November 2026), independently approved in the sshx review with run ID `37c949e5411f902b6ac0d741`. The pinned research artifacts in `petz-weighted-environment-truncation-proof` are `proof.txt` (SHA-256 `49341ee6e760de214eaf38978895658bfc174b28142edcc7401cdfba69ba2654`), `replay.py` (SHA-256 `2301116be5102ed4a6d668ba4b8ece532d91d03fdb8804af7ecc84d897cafd67`) and `independent-review-result.json` (SHA-256 `c899a5155e527aaba841474188b5be7816251d5ec55810871358883c7b0d082d`). The exact scalar replay `python3 -I -B replay.py` passed all nine open intervals using 55-digit directed Decimal arithmetic, enclosing the correctly rounded square roots and logarithms by adjacent decimals. The fidelity and Helstrom formulas used in Theorem 9.3 are standard quantum testing identities. The scope of (9.1) is equation (7) of the approved proof. Both squared scores in the witness are strictly below one. The bounded-dimension compression question for a strict margin above squared score six and the assertion $C(2)=6$ remain open.

## 追加锚（本行以下为增补区）

## 10. Protected compression, exact reverse transport and binary decision comparison

This batch extends Theorems 9.1 and 9.3 with spectral protection and ordinary Petz reverse transport. It computes the optimal binary simulation errors for Proposition 9.2 and gives a separate entropy-exact compression with strict improvement of the recomputed binary experiment. Use the notation of Section 9, including full trace norms, natural logarithms and the actual deficits. The prior Section 8 problem remains open.

**定理 10.1（Exact reverse benchmark and protected spectral threshold）。** Allow any environment-local CPTP map $\Phi=\Phi_E\otimes\mathrm{id}_B$ from $E\otimes B$ to $E'\otimes B$, and put $T'=\operatorname{Tr}_{E'}$. Define $\rho',\sigma',Y',r',\Delta'$ as in Theorem 9.1. Then $T'\Phi=T$, $0\le\Delta'\le\Delta$, and a common CPTP channel $\mathcal A$ from the compressed space to the original space has

$$
\begin{aligned}
\mathcal A_0(W)&=\sqrt\sigma\,\Phi^\dagger((\sigma')^{-1/2}W(\sigma')^{-1/2})\sqrt\sigma,\\
\mathcal A(W)&=\mathcal A_0(W)+\operatorname{Tr}((I-s')W)\tau,\qquad s'=\operatorname{supp}\sigma',
\end{aligned}
$$

where $\tau$ is any fixed original density and the inverse uses the support. The supported ordinary Petz maps compose as $R_{\sigma,T}=\mathcal A R_{\sigma',T'}$ on the retained support. In particular

$$
\mathcal A(\sigma')=\sigma,\qquad \mathcal A(Y')=Y,\qquad
r'\ge r-\|\rho-\mathcal A(\rho')\|_1.
\tag{10.1}
$$

For the projection and one-flag compressor of Theorem 9.1, let $R$ be a joint projection satisfying $R\le\operatorname{supp}\sigma$, $[R,\sigma]=0$ and $R\le\Pi=J\otimes I_B$. Put $e_R=\operatorname{Tr}(\rho(I-R))$ and $w_R=\operatorname{Tr}(Y(I-R))$. Then

$$
\begin{aligned}
(\mathcal A\Phi)(RXR)&=RXR\quad\text{for every joint operator }X,\\
\|\rho-\mathcal A(\rho')\|_1&\le \min(2,4\sqrt{e_R}),\\
a&\le 2\sqrt{w_R},\qquad w_R=\operatorname{Tr}(M\sigma(I-R)),\\
|r-r'|&\le 2\sqrt{w_\rho(1-w_\rho)}+2w_\rho+4\sqrt{w_R}
\le 2\sqrt{e_R}+2e_R+4\sqrt{w_R}.
\end{aligned}
\tag{10.2}
$$

Here $a$ and $w_\rho$ are the quantities of Section 9. For $d=\dim B$, let $\Omega=\sum_\lambda E_\lambda\rho E_\lambda$ be the pinching by the spectral projections of $\sigma$, and $e_k=1-\sum_{j=1}^k\lambda_j^\downarrow(\Omega)$, padding by zero eigenvalues. For every nonnegative integer $k$ there is a projection $J$ of rank at most $dk$ with $\dim E'\le dk+1$ and $r'\ge r-4\sqrt{e_k}$. In retained dimension two, for $\eta>0$ and $\Delta>0$ the sufficient strict threshold is

$$
\frac{r^2}{\Delta}>6+\eta,\qquad
e_k<\frac{(\sqrt{6+\eta}-\sqrt6)^2}{16}\Delta
\quad\Longrightarrow\quad
\Delta'>0,\qquad \frac{(r')^2}{\Delta'}>6 .
\tag{10.3}
$$

For any prescribed $J$ let $B_J=(\Pi\sigma\Pi)|_{\Pi}$ and use its support inverse to form $V_J=\sqrt\sigma\,\Pi B_J^{-1/2}\Pi$ (with the inverse extended by zero off the kept space). Then $\zeta_J=1-|\operatorname{Tr}(\rho V_J)|^2\ge w_\rho$ and $r'\ge r-2\sqrt{\zeta_J}$. In (10.3) the spectral condition can alternatively be replaced by $\zeta_J<(\sqrt{6+\eta}-\sqrt6)^2\Delta/4$.

Proof. Support containment gives $\rho\le c_0\sigma$ and hence $\rho'\le c_0\sigma'$. The marginals are preserved and joint data processing gives the deficit inequality. The formula for $\mathcal A_0$ is CP and its trace is $\operatorname{Tr}(s'W)$ by trace duality. The complement preparation term completes the trace. If $V_i$ are Kraus operators of $\Phi$, positivity of their contributions to $\sigma'$ gives $s'V_i\sqrt\sigma=V_i\sqrt\sigma$. Substituting the compressed ordinary Petz formula for any retained operator cancels the two inverse roots against the square roots, leaving $s'$ on either side of the lifted retained operator. Those projections disappear inside the Kraus sandwiches by the preceding identity. Since $\Phi^\dagger(I_{E'}\otimes L)=I_E\otimes L$ for every retained matrix $L$, this proves composition. Substitution of $Q$ and $P$ yields the two identities in (10.1), and contraction and the triangle inequality give its residual bound.

For spectral protection, $B_JR=RB_J=\sigma R$ on the kept space. Thus $B_J^{-1/2}R=\sigma^{-1/2}R$ and substitution into the kept part of the reverse map fixes every $RXR$. With $\Lambda=\mathcal A\Phi$, write $\rho-R\rho R=(I-R)\rho+R\rho(I-R)$. Hilbert–Schmidt Cauchy–Schwarz after factoring $\sqrt\rho$ bounds its trace norm by $2\sqrt{e_R}$. Since $\Lambda$ fixes $R\rho R$, the contraction estimate for the difference gives $\|\rho-\Lambda(\rho)\|_1\le4\sqrt{e_R}$.

For the weighted comparison decompose $\sigma=\sigma_0+\sigma_1$ with $\sigma_0=R\sigma R$ and $\sigma_1=(I-R)\sigma(I-R)$. The summands have orthogonal supports. Compression fixes $\sigma_0$ and $\Phi(\sigma_1)$ is orthogonal to $R$ in the common flagged embedding. Their square roots therefore add separately before and after compression. The common head cancels in the weighted root difference, and both tail amplitudes have squared Hilbert–Schmidt norm $\operatorname{Tr}(M\sigma_1)=w_R$ by the adjoint identity. Commutation of $R$ and $\sqrt\sigma$ proves the equality with the benchmark tail. The amplitude bound follows by the triangle inequality. The two normalized amplitudes give $\|Y-Y'\|_1\le2a$ as in Theorem 9.1. For $\rho-\rho'$ the removed off-diagonal blocks have total trace norm at most $2\sqrt{w_\rho(1-w_\rho)}$ by factoring through $\sqrt\rho$. The discarded diagonal block and the added positive flag block each have trace $w_\rho$. This gives (10.2) by the reverse triangle inequality and $w_\rho\le e_R$. In particular, to protect both weights one may pinch $(\rho+2Y)/3$ by $\sigma$ and choose its leading common eigenvectors. For a commuting $R$ with $u_R=(e_R+2w_R)/3$, (10.2) gives $|r-r'|\le6\sqrt{u_R}+6u_R$ by Cauchy–Schwarz.

The operator $\Omega$ commutes with $\sigma$ and is supported on its positive support. Choose $R$ from a common eigenbasis on that support, taking the first $k$ eigenvectors of $\Omega$ or the whole support if $k$ exceeds its dimension. Then $e_R=e_k$. Expanding these vectors in a retained basis of size $d$ gives at most $dk$ environment coordinates spanning a space whose projection $J$ protects $R$. This includes $k=0$, where the source and benchmark after compression both equal $P$ and the deficit is zero. For a positive spectral cutoff of $\sigma$ the same reasoning applies to its spectral projection, with the corresponding source and benchmark weights in (10.2). A cutoff at zero may use the positive support. Under the strict condition in (10.3), (10.1)–(10.2) imply $r'>\sqrt{6\Delta}\ge\sqrt{6\Delta'}$. If $\Delta'=0$, supported Petz equality for $T'$ forces $\rho'=Y'$, a contradiction.

The kept-to-kept branch of $\Lambda$ has Kraus operator $V_J$. Its adjoint product is the kept reference support projection on $\Pi$. Since $\rho\le c_0\sigma$, $\operatorname{Tr}(\rho V_J^\dagger V_J)=1-w_\rho$. Cauchy–Schwarz gives $\zeta_J\ge w_\rho$. For a purification of $\rho$, the squared overlap of the original purification with its image by $\Lambda$ is the sum of $|\operatorname{Tr}(\rho V)|^2$ over Kraus operators $V$ of $\Lambda$. It is at least $1-\zeta_J$. The pure-state fidelity–trace bound for a pure density and an arbitrary density, followed by partial-trace contraction, gives $\|\rho-\Lambda(\rho)\|_1\le2\sqrt{\zeta_J}$. Applying (10.1) proves the alternate condition by the same threshold argument.

**定理 10.2（Reverse transport of the actual tensor-power experiment）。** For every integer $N\ge1$ define the ordered binary experiments $O_N=(\rho^{\otimes N},Y^{\otimes N})$ and $C_N=((\rho')^{\otimes N},(Y')^{\otimes N})$ on their actual joint carriers. The copywise compression uses independent flags when $\Phi$ is the compressor of Section 9. Define directed deficiency for any two ordered binary experiments $U=(U_0,U_1)$ and $V=(V_0,V_1)$ by

$$
\delta(U\to V)=\inf_{\Gamma\ {\rm CPTP}}\max_{i=0,1}\|\Gamma(U_i)-V_i\|_1.
$$

For the hypotheses of Theorem 10.1, the product reverse channel $\mathcal A_N=\mathcal A^{\otimes N}$ sends both compressed benchmark and reference exactly to the original tensor powers. In the protected projection setting put $e_N=1-(1-e_R)^N$ and $g=(1-2w_R)_+$. With $q_N=\|\rho^{\otimes N}-\mathcal A_N((\rho')^{\otimes N})\|_1$,

$$
\begin{aligned}
\delta(C_N\to O_N)&\le q_N\le \min(2,4\sqrt{e_N}),\\
q_N&\le 2\sqrt{1-(1-2e_N)_+^2},\\
\|\Phi^{\otimes N}(Y^{\otimes N})-(Y')^{\otimes N}\|_1
&\le 2\sqrt{1-g^{2N}}\le\min(2,4\sqrt{Nw_R}).
\end{aligned}
\tag{10.4}
$$

For any prior $\pi$ on the first hypothesis and any finite decision problem with losses in $[0,1]$, the infimum of Bayes risk over collective POVMs on $C_N$ is at most the corresponding risk on $O_N$ plus $\pi q_N/2$. Along positive-deficit families with bounded $N\Delta$, $e_R=o(\Delta)$ suffices for vanishing reverse simulation error. With the additional condition $w_R=o(\Delta)$ the prescribed forward simulation error vanishes as well.

Proof. Ordinary Petz benchmarks tensorize by multiplicativity of partial traces, roots and support inverses. The product channel has exact benchmark and reference recovery by (10.1). Also $(\mathcal A_N\Phi^{\otimes N})(R^{\otimes N}XR^{\otimes N})=R^{\otimes N}XR^{\otimes N}$ on every joint operator, by expanding within the protected subspace in tensor matrix units. The protected source tail equals $e_N\le Ne_R$. The gentle estimate of Theorem 10.1 gives the first bound. The Kraus operator $V_J$ is a contraction with $V_J R=R$ and $V_J^\dagger R=R$, the second identity following from contraction and the first. Hence $V_J^{\otimes N}$ is the identity on $R^{\otimes N}$, with zero cross blocks and complementary norm at most one. The real part of its expectation under $\rho^{\otimes N}$ is at least $1-2e_N$. The purification argument of Theorem 10.1 gives the second bound. For the forward estimate the normalized amplitudes have real overlap $1-a^2/2\ge1-2w_R$, giving root fidelity at least $g$. Fidelity multiplicativity, the fidelity–trace bound and contraction under the compressor give the forward estimate on the actual output. The source maps forward exactly. More precisely, for $F=f(\Phi Y,Y')$ the forward benchmark tensor error vanishes along a sequence exactly when $N(1-F)\to0$, by $2(1-F^N)\le\|(\Phi Y)^{\otimes N}-(Y')^{\otimes N}\|_1\le2\sqrt{1-F^{2N}}$.

For a POVM on $O_N$, its pullback by $\mathcal A_N^\dagger$ is a POVM on $C_N$. Each hypothesis contributes an expected loss given by an effect between zero and the identity, namely the sum of POVM effects weighted by the loss for that hypothesis. Its change in expectation is bounded by half the full trace error since the state error is traceless. The benchmark error is zero, yielding the prior-weighted assertion. Taking infima and using $e_N\le Ne_R$ proves the limits. A single global projection onto $J^{\otimes N}$ followed by one external flag is also allowed in Theorem 10.1, with $e_R,w_R$ replaced by $1-(1-e_R)^N,1-(1-w_R)^N$. Its benchmark is recomputed on that global-flag space. Both copy constructions have retained dimension $d^N$.

**定理 10.3（Exact deficiency for two pure hypotheses）。** Let $U_i=P_{u_i}$ and $V_i=P_{v_i}$ be pairs of unit-vector densities on arbitrary nonzero finite-dimensional carriers. For $a_0=|\langle u_0,u_1\rangle|$, $b_0=|\langle v_0,v_1\rangle|$ and $s_c=\sqrt{1-c^2}$, one has

$$
\delta(U\to V)=(s_{b_0}-s_{a_0})_+,
\tag{10.5}
$$

with attainment by a common CPTP map on the full carriers.

Proof. The trace norms of the pure contrasts are $2s_{a_0}$ and $2s_{b_0}$, using the two-dimensional span and determinant of the difference. Contractivity and the triangle inequality give the lower bound. Rephase the second vector in each pair for real nonnegative overlap. For any such pair $(z_0,z_1)$ with overlap $c<1$, its orthonormal sum and difference vectors are $(z_0+z_1)/\sqrt{2(1+c)}$ and $(z_0-z_1)/\sqrt{2(1-c)}$. Let the map from $\mathbb C^2$ into the carrier with these columns be denoted by $U_z$. For $c=1$ take columns $z_0,0$. On the canonical qubit the two pure projectors are $(I+(-1)^i s_c X+c Z)/2$, where $X$ interchanges coordinates and $Z=\operatorname{diag}(1,-1)$. Their images by $U_z$ give the original states also at $c=1$.

If $a_0\ge b_0$, $a_0>0$ and $b_0<1$, use $U=U_u$, $V=U_v$, $P_U=UU^\dagger$, $p_0=(1+b_0/a_0)/2$ and any fixed target density $\tau$. The channel is

$$
\Gamma(W)=p_0 VU^\dagger WUV^\dagger
 +(1-p_0)VXU^\dagger WUXV^\dagger
 +\operatorname{Tr}((I-P_U)W)\tau.
\tag{10.6}
$$

The first two Kraus adjoint products sum to $P_U$ because $V^\dagger V=I$. The last term is CP with Kraus adjoint products summing to $I-P_U$, as is seen by taking a spectral decomposition of $\tau$ and a basis of the complementary input subspace. On the input span the canonical transformation fixes the $X$ coefficient and scales the $Z$ coefficient by $b_0/a_0$. Both output differences have eigenvalues $\pm(s_{b_0}-s_{a_0})/2$, proving attainment including the rank-one input encoding with $a_0=1$.

If $a_0\le b_0$ and $b_0>0$, use unit ancilla vectors $\eta_0=(1,0)$ and $\eta_1=(a_0/b_0,\sqrt{1-(a_0/b_0)^2})$. The product vectors $v_i\otimes\eta_i$ have the same Gram matrix as the $u_i$. The linear map $W_0u_i=v_i\otimes\eta_i$ is consequently well-defined and isometric on their span. Extend it by zero on the complement and send $W$ to $\operatorname{Tr}_{\rm anc}(W_0WW_0^\dagger)+\operatorname{Tr}((I-P_U)W)\tau$. The partial trace Kraus adjoint products sum to $P_U$ and the complement term supplies the remainder. This maps both hypotheses exactly. At $a_0=b_0=0$ a span isometry with the same complement term gives exactness. At $b_0=1$ the constant channel to $V_0$ also suffices, including the one-dimensional target. These cases exhaust the overlap endpoints.

**定理 10.4（Optimal directed errors for Proposition 9.2）。** Use precisely the states $v,h,d$ and the slopes $\alpha,1/2,\beta$ of Proposition 9.2. Write $c_h=|\langle v,h\rangle|$, $c_d=|\langle v,d\rangle|$, $c_{hd}=|\langle h,d\rangle|$. For every integer $N\ge1$,

$$
\begin{aligned}
\delta(O_N\to C_N)&=0,\\
\delta(C_N\to O_N)&=\delta_N=\sqrt{1-c_h^{2N}}-\sqrt{1-c_d^{2N}}>0,\\
B_N&=2\sqrt{1-c_{hd}^{2N}} .
\end{aligned}
\tag{10.7}
$$

With the added constraint that a simulator preserve the retained input marginal on the benchmark hypothesis, the optimum in each direction is $B_N$. This includes all collective environment-only CPTP channels with the identity on the retained factors. In particular $\delta_N\le B_N/2<B_N$. For an arbitrary finite decision set and losses in $[0,1]$, the compressed optimal risk minus the original optimal risk lies in $[0,\delta_N/2]$, and its supremum over such problems and priors is $\delta_N/2$.

Proof. The actual benchmarks from the two references are the pure kept states of Proposition 9.2. The overlap of real unit vectors of positive first coordinate and slopes $x,y$ is $(1+xy)/\sqrt{(1+x^2)(1+y^2)}$. The angle order $0<\alpha<\beta<1/2$ gives $0<c_h<c_d<1$ and $0<c_{hd}<1$. Tensorization gives overlaps $c_h^N,c_d^N$ and Theorem 10.3 yields (10.7). Explicitly for reverse simulation let the input isometry $U$ have sum and difference columns of the two vectors $(|0\rangle\otimes v)^{\otimes N},(|0\rangle\otimes d)^{\otimes N}$ in the compressed kept block, and the target isometry $V$ have the columns from $(|0\rangle\otimes v)^{\otimes N},(|0\rangle\otimes h)^{\otimes N}$ on the original carrier. In (10.6) take $p_0=(1+(c_h/c_d)^N)/2$ and $\tau=\rho^{\otimes N}$ to obtain both errors equal to $\delta_N$. The exact forward channel is the ancillary construction in Theorem 10.3 with the spans interchanged, ancilla overlap $(c_h/c_d)^N$ and target complement density $(\rho')^{\otimes N}$. The maps use the joint pair spans and act also on the unused flag coordinates through the complement term. The one-copy exact forward channel can also be tensorized. Since the two nonorthogonal inputs have distinct pure outputs, an exact measure-and-prepare realization would require disjoint outcome laws to prepare them, which trace contractivity forbids.

Under retained-benchmark-marginal preservation, the partial trace of the benchmark error already has norm $B_N$ by the pure trace-distance formula. The physical product compressor and Section 9 decoder attain this bound in their respective directions since they fix the kept block and send the source exactly. The triangle inequality on the retained pure densities gives $2\delta_N\le B_N$. Thus an unrestricted exact forward simulator must change the benchmark retained marginal, and any optimal unrestricted reverse simulator changes it as well. Both environment marginals of each pair are the same kept pure factor. An environment-only measurement therefore has the same law on both hypotheses.

For a pure pair of overlap $c$ and prior $\pi\in[0,1]$ on the first hypothesis, the optimum binary zero-one loss is

$$
e(c,\pi)=\frac{1-\sqrt{1-4\pi(1-\pi)c^2}}{2}.
\tag{10.8}
$$

Indeed on the span the prior-weighted difference has trace $2\pi-1$ and determinant $-\pi(1-\pi)(1-c^2)$, and the positive spectral projector maximizes the correct decision probability against effects between zero and the identity. The scalar cases at prior or overlap endpoints give the same formula. Taking $c=c_h^N,c_d^N$ proves a strictly positive risk gap at every interior prior. Rationalizing the difference of square roots shows that it increases with $4\pi(1-\pi)$, so its maximum is $\delta_N/2$ at $\pi=1/2$. For general bounded losses the exact forward channel allows every compressed decision to be reproduced on the original pair. Conversely, pullback through the reverse optimizer increases each conditional loss by at most $\delta_N/2$ times its maximum loss, by the effect estimate in Theorem 10.2. This yields the risk bound, with the maximum attained by equal-prior binary loss. It is also the classical decision-procedure deficiency in the half-trace-norm convention for this pair. At fixed interior prior and fixed states, (10.8) gives $e(c^N,\pi)\sim\pi(1-\pi)c^{2N}$. The two Chernoff rates are $-2\log c_h$ and $-2\log c_d$, respectively, and $\delta_N\sim c_d^{2N}/2$ while $B_N\to2$.

For the faithful approximation of Proposition 9.2, these directed deficiencies converge at each fixed $N$. Indeed changing both pairs changes the objective of every common CPTP simulator by at most the sum of the maximum trace distances within the two perturbed pairs, by contraction and triangle inequalities. This bound passes to the infima, and tensor powers converge by telescoping. The retained-marginal-preserving optima also converge to $B_N$ by the partial-trace lower bound and the errors of the prescribed compressor and decoder. The strictly positive reverse deficiency and strict fixed-interior-prior testing gap persist sufficiently near the limiting pure model at each fixed $N$.

**定理 10.5（Entropy-exact compression and strict reverse decision comparison）。** In the general setting of Theorem 10.1, assume $D(\rho\Vert\sigma)=D(\rho'\Vert\sigma')$. Then $\Delta'=\Delta$ and $\mathcal A(\rho')=\rho$ by supported Petz equality, so $r'\ge r$ and for $\Delta>0$ the squared score cannot decrease. In every finite tensor power the common channel $\mathcal A_N$ simulates the original actual binary experiment exactly from the compressed experiment. In particular $\delta(C_N\to O_N)=0$ and every Bayes risk for arbitrary collective POVMs and finite decisions weakly decreases under this compression.

For a prior $\pi$ let $Z'_N=\pi(\rho')^{\otimes N}-(1-\pi)(Y')^{\otimes N}$ and $Z_N=\pi\rho^{\otimes N}-(1-\pi)Y^{\otimes N}$. With Jordan parts $(Z'_N)_+,(Z'_N)_-$, equality of the two Helstrom risks holds precisely when

$$
\mathcal A_N((Z'_N)_+)\,\mathcal A_N((Z'_N)_-)=0 .
\tag{10.9}
$$

There is a strict example of this entropy equality with faithful joint reference on $\mathbb C^2\otimes\mathbb C^2$ and environment dephasing. It has pure source, positive deficit and $r'>r$. At every finite $N$ and every interior prior the compressed actual error is strictly lower. Its genuine projection-and-one-flag extension with environment dimensions three to two also has faithful reference and the same strict testing property.

Proof. Exact recovery of the source follows from the equality theorem on compatible supports. The reverse recovery of the benchmark and reference follows from (10.1). Hence contractivity orders the residuals and the adjoint POVM pullback reproduces all conditional laws at each $N$. For any Hermitian $Z'=Z'_+-Z'_-$ put $U=\mathcal A_N(Z'_+)$ and $V=\mathcal A_N(Z'_-)$. The trace norm equals $\operatorname{Tr}U+\operatorname{Tr}V$ exactly when these positive operators have orthogonal supports. In the equality direction, take a norming Hermitian contraction $H$ for $U-V$. The nonnegative traces $\operatorname{Tr}((I-H)U)$ and $\operatorname{Tr}((I+H)V)$ sum to zero, and their vanishing puts the respective supports in the $+1$ and $-1$ eigenspaces of $H$. Orthogonality gives the converse by simultaneous diagonalization. Since the Helstrom value is $(1-\|Z_N\|_1)/2$ by maximizing the contrast over effects, this proves (10.9). In Kraus terms, equality holds exactly when every Kraus image of the positive support is orthogonal to every Kraus image of the negative support. This follows because a sum of positive operators has support equal to the span of their supports. If also $\Phi(Y)=Y'$, the two channels map the actual hypotheses in both directions, giving equality of their decision regions.

For the strict example work in environment-first order and let $J_0,J_1$ be the embeddings of the retained $\mathbb C^2$ into environment levels zero and one. Write $e_0,e_1$ for the retained coordinate vectors and set

$$
H_*=\operatorname{diag}(2,1),\qquad G_*=\operatorname{diag}(0,1),\qquad
C_*=\begin{pmatrix}2&1\\1&2\end{pmatrix},\qquad
S_*=\frac1{\sqrt{17}}\begin{pmatrix}H_*&G_*\\G_*&C_*\end{pmatrix}.
$$

The Schur complement of $H_*$ in the unnormalized block matrix is $\begin{pmatrix}2&1\\1&1\end{pmatrix}>0$, so $S_*>0$. Take $\sigma=S_*^2$, $u=J_0e_0$, $\rho=P_u$. Multiplication gives the kept, cross and second diagonal blocks of $17\sigma$ as

$$
\operatorname{diag}(4,2),\qquad\begin{pmatrix}0&0\\1&3\end{pmatrix},\qquad
\begin{pmatrix}5&4\\4&6\end{pmatrix}.
$$

Their diagonal traces sum to $17$, proving normalization and faithfulness. Compress by dephasing the two environment levels, labeling the second level as the flag. Thus $\sigma'=D_*^2\oplus F_*$ where $D_*=\operatorname{diag}(2,\sqrt2)/\sqrt{17}$ and $F_*=\begin{pmatrix}5&4\\4&6\end{pmatrix}/17$. The joint source remains the same pure kept state and its eigenvalue in each reference is $4/17$, giving $D(\rho\Vert\sigma)=D(\rho'\Vert\sigma')=\log(17/4)$. The retained marginals are $P=P_{e_0}$ and $Q=M_*/17$ with $M_*=\begin{pmatrix}9&4\\4&8\end{pmatrix}$. Put $l=Q^{-1/2}e_0$. By the two-by-two square-root identity in Proposition 9.2,

$$
l_0>0,\qquad z=l_1/l_0=-4/(8+\sqrt{56})\in(-1/3,0),
\qquad l_0+3l_1>0,\qquad l^\dagger Ql=1.
$$

The eigenvalues of $M_*$ are $(17\pm\sqrt{65})/2$ and their weights in $e_0$ are $(1\pm1/\sqrt{65})/2$. Consequently

$$
\Delta=\Delta'=\frac12\left[
(1+1/\sqrt{65})\log\frac{17+\sqrt{65}}8+
(1-1/\sqrt{65})\log\frac{17-\sqrt{65}}8
\right]>0 ,
$$

because both log arguments exceed one.

The recomputed benchmark has two orthogonal flag blocks $Y'=|a_*\rangle\langle a_*|\oplus|b_*\rangle\langle b_*|$ with $a_*=D_*l$, $b_*=\sqrt{F_*}l$, and $\|a_*\|^2+\|b_*\|^2=1$. The original benchmark is $Y=|S_*J_0l\rangle\langle S_*J_0l|+|S_*J_1l\rangle\langle S_*J_1l|$. The reverse Kraus embeddings on the two blocks are $L_0=S_*J_0 D_*^{-1}$ and $L_1=S_*J_1 F_*^{-1/2}$, both isometries by the displayed diagonal blocks. Their cross vector is

$$
L_0^\dagger L_1 b_*=D_*^{-1}J_0^\dagger\sigma J_1 l
 =c_* e_1,\qquad c_*=(l_0+3l_1)/\sqrt{34}>0 .
\tag{10.10}
$$

For every finite $N\ge1$ and interior prior, the all-kept block of $Z'_N$ is the difference of positive rank-one terms $\pi P_{e_0^{\otimes N}}-(1-\pi)|a_*^{\otimes N}\rangle\langle a_*^{\otimes N}|$. Their vectors are independent since both entries of $a_*$ are nonzero. The determinant of the difference on their span is negative, by expanding the second vector in the first vector and its orthogonal complement. It has one positive eigenvector $w_N=\alpha_N e_0^{\otimes N}+\beta_N a_*^{\otimes N}$ with $\beta_N\ne0$, because $\langle a_*^{\otimes N},e_0^{\otimes N}\rangle\ne0$ and the first vector is neither parallel nor orthogonal to the second. The sector with the first copy flagged and the others kept contributes the nonzero negative ket $b_*\otimes a_*^{\otimes(N-1)}$. Under the respective Kraus products the inner product of these positive and negative kets equals

$$
\langle w_N,c_* e_1\otimes a_*^{\otimes(N-1)}\rangle
=c_*\overline{\beta_N}\,\overline{(a_*)_1}\,\|a_*\|^{2(N-1)}\ne0 .
$$

By (10.9) the contraction under $\mathcal A_N$ is strict, so the compressed Helstrom error is strictly lower. At endpoint priors both errors vanish. At equal priors and one copy this gives $r'>r$. For all finite $N$, any forward CPTP simulator has error at least $\big(\|(\rho')^{\otimes N}-(Y')^{\otimes N}\|_1-\|\rho^{\otimes N}-Y^{\otimes N}\|_1\big)/2>0$ by contraction and the triangle inequality. The physical pushforward $\Phi(Y)$ has faithful blocks since $H_*l,G_*l$ are independent and $G_*l,C_*l$ are independent. The recomputed $Y'$ has rank two. The original pure source $u$ lies outside the support spanned by $S_*J_0l,S_*J_1l$, since $S_*u$ is proportional to $u$ and $l$ is nonparallel to $e_0$. Thus recovery of the physical transported pair $(\rho',\Phi(Y))$ is also impossible, since $\rho'\le c\Phi(Y)$ for a finite $c$ would imply the corresponding support containment of their recovered images.

For an actual reduction of dimension three to two let $0<\theta<1$, add an isolated environment level two and set $\sigma_\theta=(1-\theta)\sigma\oplus\theta Q$ with source $u$ supported on level zero as before. Keep level zero and send levels one and two into the same external flag by the channel of Theorem 9.1. This has faithful reference and retained marginal $Q$, and the source eigenvalue in both references is $(1-\theta)4/17$. The joint relative entropy is preserved and the deficit is $\Delta_\theta=\Delta-\log(1-\theta)>0$. The compressed reference has kept root $D_\theta=\sqrt{1-\theta}\,D_*$ and flag block $F_\theta=(1-\theta)F_*+\theta Q$. Its two benchmark vectors are $a_\theta=D_\theta l$ and $b_\theta=\sqrt{F_\theta}l$. The kept reverse Kraus operator $\sqrt{\sigma_\theta}J_0D_\theta^{-1}$ is an isometry. One of the flag reverse Kraus operators is $\sqrt{\sigma_\theta}J_1 F_\theta^{-1/2}$, using level one. Its action on $b_\theta$ gives $\sqrt{\sigma_\theta}J_1l$. The cross vector in (10.10) is now $\sqrt{1-\theta}\,c_* e_1$. Both coordinates of $a_\theta$ remain nonzero. The entire tensor-power overlap argument applies with these substituted vectors, selecting that flag Kraus branch and the kept isometries for the other factors. The nonorthogonal images persist in the positive Kraus sums regardless of the additional flag branch. This proves strict comparison at all finite copy counts and interior priors for each fixed $\theta$.

For either fixed reference, mixing the source with the reference as $\rho_t=(1-t)\rho+t\sigma$ (or with $\sigma_\theta$) gives faithful joint pairs at $0<t<1$. The reverse channel recovers the mixture exactly, so two-way data processing proves entropy equality. By linearity of the retained ordinary Petz map, the recomputed benchmarks mix with their respective references in the same proportions. The one-copy residuals scale by $1-t$, preserving strictness and positivity and hence positive deficits by supported equality. For any fixed $N$ and interior prior, strict testing persists for sufficiently small $t>0$ by continuity of the tensor contrasts. The pure-source all-prior conclusion is for the unmixed witness. For fixed positive mixing in finite dimensions the hypotheses are faithful and sufficiently close to an endpoint prior both contrasts are sign-definite, yielding the same trivial risk.

**命题 10.6（Limits of the comparison criteria）。** Under the hypotheses of Theorem 10.1 without entropy equality, write $g_N(\pi)=\|Z'_N\|_1-\|\mathcal A_N(Z'_N)\|_1$ and $q_N$ as in Theorem 10.2. Then

$$
g_N(\pi)\ge0,\qquad
\left|\|Z'_N\|_1-\|Z_N\|_1-g_N(\pi)\right|\le \pi q_N,\qquad
q_N\le\min(2,Nq_1).
$$

In particular $g_N(\pi)>\pi q_N$ suffices for strict improvement of binary testing by compression even with approximate source recovery. Also, if a hypothetical positive-deficit witness has $r^2/\Delta>6+\eta$ for $\eta>0$, adjoining a common maximally mixed environment spectator of dimension $s$ gives the same score while its protected spectral tail at every fixed joint rank $k$ tends to one as $s\to\infty$.

Proof. Contractivity proves nonnegativity of $g_N$. The benchmark is recovered exactly, so the difference between $Z_N$ and $\mathcal A_N(Z'_N)$ has trace norm $\pi q_N$. Telescoping the product densities proves the last bound. For the spectator, let $\omega_s=I_s/s$ and tensor it with both original states, permuting it into the environment. Product entropy cancellation, trace-norm multiplicativity and the Petz root formula show that $\Delta,r$ are preserved and the benchmark becomes $Y\otimes\omega_s$. The pinched source becomes $\Omega\otimes\omega_s$ because the distinct eigenvalues of the joint reference are those of $\sigma$ scaled by $1/s$, with corresponding projections $E_\lambda\otimes I_s$. Its top-$k$ mass is at most $k\|\Omega\|_\infty/s$. The conditional obstruction pertains to a rank bound obtained solely from such normalized spectral tails. For example a projection keeping the whole original environment and a fraction $\alpha>0$ of spectator coordinates gives $r'=\alpha r$ and $\Delta'=\alpha\Delta$, by direct sum decomposition of the kept product block and the flag pair $P,Q$. Its squared score is $\alpha r^2/\Delta$. Discarding the common spectator by partial trace itself is an entropy-exact environment compression.

### 10.7 Sources, scope and verification

Theorems 10.1–10.2 and the spectral-tail limitation in Proposition 10.6 use “A spectral-tail theorem sufficient to retain a score above six” and its independent ordinary proof of same-copy reverse transport. The supplied research directory is *petz-weighted-environment-truncation-review*. Its answer.txt has SHA-256 1749851617140073627f4871f69e82e601f92e3fe814894e3f7f85ad6aad5b86 and its independent-review-result.json has SHA-256 90dadef79dd41f85aadccea2b71ba43935c3c09dc36c8ea466ffb807176c8643. The approved review run is 51abfd80ed1276406cab9410.

Theorems 10.3–10.4 use “Exact binary quantum experiment deficiency for the weighted Petz obstruction” in *petz-weighted-truncation-binary-deficiency*. The approved proof.txt has SHA-256 07ca5ee995e9611c29af06224ddf1a5676310f7b8ddfbb228028deb9f31bcd6d and its independent-review-result.json has SHA-256 1130f0e8416c2eb49840e9782d31f4fc57f64e822159418ddbdc6c5b32ffe882. The approved review run is 57c79550b610f3aa2da4822e. Its pinned finite matrix replay tested the actual pair and channels for $N=1,2,3$ with endpoint and unequal-carrier cases. Independent exact arithmetic certified the scalar enclosures. In particular the one-copy reverse unhalved deficiency is approximately $0.0343183305783$, the maximum bounded-loss risk gap is $0.0171591652892$ and the retained-marginal-preserving unhalved deficiency is $0.0690038604283$.

Theorem 10.5 and the approximate testing bound in Proposition 10.6 use “Entropy-exact environment compression and ordinary Petz testing” in *petz-entropy-exact-compression-score*. The approved proof.txt has SHA-256 98777ba77c725ffe7ab80987553020b772f1446684852044242e34b5bc6e4dfe and its independent-review-result.json has SHA-256 89f20da3d7696c66b4a68c73b0d355141aa926d75139be77d0551e36a6353810. The approved review run is dfd70c403cf0eb111c9580e2. The pinned rational replay and independent matrix calculation certified the base dephasing values $0.966719838800<r<0.966719838802$, $0.966849221413<r'<0.966849221415$ and $0.690326352952<\Delta<0.690326352955$. The corresponding squared scores lie in $(1.35377599,1.35377601)$ and $(1.35413838,1.35413841)$. The strict analytic overlap proof covers the entire family of finite copy counts and interior priors specified above.

The ordinary proofs and explicit channel constructions are repo-derived, assembled by an sshx implementation worker using the three independently approved research inputs with hashes checked against the receipts. The literature-attested equality and completion ingredients follow Petz, *Sufficient subalgebras and the relative entropy of states of a von Neumann algebra*, CMP 105 (1986), 123–131, and *Sufficiency of channels over von Neumann algebras*, QJM 39 (1988), 97–108, with local source suppliers CanonicalPetzEquality.lean and ReferencePetzChannel.lean cited by the research reviews. The exact pure-state Gram construction is the binary instance of Chefles, Jozsa and Winter, *On the existence of physical transformations between sets of quantum states*, IJQI 2 (2004), 11–21, Theorem 2 [arXiv:quant-ph/0307227](https://arxiv.org/abs/quant-ph/0307227). Related comparison locators are Alberti and Uhlmann, Rep. Math. Phys. 18 (1980), 163–176, and Jenčová, *Comparison of quantum binary experiments*, Rep. Math. Phys. 70 (2012), 237–249, Sections 3–4 [arXiv:1110.4792](https://arxiv.org/abs/1110.4792). The latter identifies the classical decision and testing deficiency conventions, with the general equivalence against every comparator restricted to abelian source experiments. The equality of decision and state-simulation deficiencies here follows from the explicit pure-pair optimizers. The Gram and sum/difference constructions also draw on the local GramIsometryExtension.lean and BinaryPureRecordDecoding.lean source locators. The standard Holevo–Helstrom formula and quantum Chernoff bound of Audenaert et al., Phys. Rev. Lett. 98 (2007), 160501, provide the testing antecedents. The attribution is scoped to the inspected local sources and the review receipts.

The protected-tail threshold gives a conditional finite-dimensional reduction. Every available entropy-exact environment compressor preserves a strict input squared score above six, when such an input exists. The obstruction of Proposition 9.2 has scores below one, and the base faithful-reference example in Theorem 10.5 has scores below two. Uniform bounded-output compression on the strict-score class and the assertion $C(2)=6$ of Section 8 remain outstanding. The current proofs have ordinary mathematical status.

## 追加锚（本行以下为增补区）

## 11. Ordinary Petz benchmark drift under environment erasure

Use the setting of Section 9 with retained qubit $B$, finite environment $E$, and joint densities $\rho,\sigma$ satisfying $\operatorname{supp}\rho\subseteq\operatorname{supp}\sigma$. Write $P=\operatorname{Tr}_E\rho$, $Q=\operatorname{Tr}_E\sigma>0$, and $L=Q^{-1/2}PQ^{-1/2}$. For any CPTP map $T:E\to F$, set $\Phi=T\otimes\mathrm{id}_B$, $\sigma'=\Phi(\sigma)$ and $\rho'=\Phi(\rho)$. The marginals of $\rho',\sigma'$ are still $P,Q$. Put
$$
Y=\sqrt{\sigma}(I_E\otimes L)\sqrt{\sigma},\qquad
Y_0=\Phi(Y),\qquad Y_1=\sqrt{\sigma'}(I_F\otimes L)\sqrt{\sigma'}.
$$
Both benchmarks have trace $\operatorname{Tr}(QL)=1$ and are supported on $\sigma'$. Use ordinary traces, natural logarithms, unhalved trace norms, root fidelity $f(U,V)=\|\sqrt U\sqrt V\|_1$, and $d_{\rm B}^2(U,V)=2(1-f(U,V))$. Write $\Delta=D(\rho\Vert\sigma)-D(P\Vert Q)$ and $\Delta_T=D(\rho'\Vert\sigma')-D(P\Vert Q)$.

**Theorem 11.1 (The Pauli Gram defect).** For every such pair and channel,
$$
\Gamma=\operatorname{Tr}_B L\bigl(\operatorname{Tr}_F Y_1-\operatorname{Tr}_E Y\bigr)\ge0,
\qquad \|Y_1-Y_0\|_1^2\le\Gamma.
\tag{11.1}
$$
In particular, equality of the retained benchmark marginals at the actual $P$ is equivalent to $Y_0=Y_1$.

Proof. On complex Hilbert–Schmidt spaces let $\mathcal L_\omega,\mathcal R_\omega$ denote left and right multiplication by $\omega$, and let $\mathcal K_\omega(X)=\sqrt\omega X\sqrt\omega$. The block operator with diagonal $\mathcal L_\sigma,\mathcal R_\sigma$ and off-diagonal $\mathcal K_\sigma$ is positive by factoring it with the column $(\mathcal L_\sigma^{1/2},\mathcal R_\sigma^{1/2})^{\mathsf T}$. Conjugate by $\operatorname{diag}(\Phi,\Phi)$. Unital Schwarz for $\Phi^\dagger$ bounds the resulting diagonals above by $\mathcal L_{\sigma'},\mathcal R_{\sigma'}$. For the left diagonal the quadratic form is bounded by $\operatorname{Tr}\sigma\,\Phi^\dagger(XX^\dagger)=\operatorname{Tr}\sigma'XX^\dagger$, and the right diagonal uses $X^\dagger X$ instead.

Write $U=\Phi\mathcal K_\sigma\Phi^\dagger\succeq0$ for the off-diagonal operator. Add $tI$ to the enlarged diagonals to obtain commuting positive definite operators $A_t,B_t$. The Schur complement gives $(A_t^{-1/2}UA_t^{-1/2})^2\preceq A_t^{-1/2}B_t A_t^{-1/2}$. Monotonicity of the positive square root gives $U\preceq A_t^{1/2}B_t^{1/2}$. Let $t\downarrow0$. Thus, including for singular references,
$$
0\preceq\mathcal D:=\mathcal K_{\sigma'}-\Phi\mathcal K_\sigma\Phi^\dagger
\preceq\mathcal K_{\sigma'},\qquad \mathcal D(I)=0.
$$
The identity follows from $\Phi^\dagger(I)=I$ and $\Phi(\sigma)=\sigma'$. For $\widehat L=I_F\otimes L$, the adjoint sends $\widehat L$ to $I_E\otimes L$. Hence $\mathcal D\widehat L=Y_1-Y_0$ and $\Gamma=\langle\widehat L,\mathcal D\widehat L\rangle$. For every Hermitian $H$,
$$
|\operatorname{Tr}H(Y_1-Y_0)|^2\le\Gamma\langle H,\mathcal D H\rangle
\le\Gamma\operatorname{Tr}(\sigma'H^2).
\tag{11.2}
$$
The last step uses $\sqrt{s_i s_j}\le(s_i+s_j)/2$ in a $\sigma'$ eigenbasis. Taking the supremum over Hermitian contractions gives (11.1). The three standard Pauli matrices $X_i$ are unscaled, with $\operatorname{Tr}X_iX_j=2\delta_{ij}$. Their lifts $\widehat X_i=I_F\otimes X_i$ give the real positive semidefinite matrix $G_{ij}=\langle\widehat X_i,\mathcal D\widehat X_j\rangle$. If $L=\ell_0 I+\sum_i\ell_iX_i$, then $\Gamma=\ell^{\mathsf T}G\ell$ by $\mathcal D(I)=0$.

**Theorem 11.2 (Comparison at positive likelihood floor).** If $P\succeq mQ$ for any $m>0$, then
$$
d_{\rm B}^2(Y_0,Y_1)\le\frac{\Gamma}{4m},\qquad
\|Y_0^{\otimes N}-Y_1^{\otimes N}\|_1\le\min\{2,\sqrt{N\Gamma/m}\}
\quad(N\ge1).
\tag{11.3}
$$
There is no lower eigenvalue requirement on $Q$ beyond positivity or on the nonzero spectrum of $\sigma'$.

Proof. Both benchmarks dominate $m\sigma'$. For a POVM $(E_j)$ put $s_j=\operatorname{Tr}\sigma'E_j$, $u_j=\operatorname{Tr}Y_0 E_j$, $v_j=\operatorname{Tr}Y_1 E_j$, omitting $s_j=0$ since $u_j=v_j=0$ there. Apply (11.2) to $H=\sum_j h_j E_j$. Unital Schwarz gives $H^2\preceq\sum_j h_j^2E_j$ for real $h_j$. Taking $h_j=(v_j-u_j)/s_j$ yields $\sum_j(v_j-u_j)^2/s_j\le\Gamma$. Since $u_j,v_j\ge ms_j$, the squared Hellinger distance $\sum_j(\sqrt{u_j}-\sqrt{v_j})^2$ is at most $\Gamma/(4m)$.

On $\operatorname{supp}\sigma'$ measure the spectral projections of $C=Y_0^{-1/2}\sqrt{Y_0^{1/2}Y_1Y_0^{1/2}}\,Y_0^{-1/2}$. Since $Y_1=CY_0 C$, an eigenvalue $c_j$ gives $v_j=c_j^2u_j$. The resulting affinity is $\sum_j\sqrt{u_jv_j}=\operatorname{Tr}(CY_0)=f(Y_0,Y_1)$, giving the Bures bound. In general, fidelity multiplicativity and the trace-distance–fidelity inequality give
$$
\|Y_0^{\otimes N}-Y_1^{\otimes N}\|_1
\le 2\sqrt{1-f(Y_0,Y_1)^{2N}}
\le 2\sqrt{N d_{\rm B}^2(Y_0,Y_1)}.
\tag{11.4}
$$

With prior $w$ on the benchmark, replacing $Y_0^{\otimes N}$ by $Y_1^{\otimes N}$ in the encoded experiment with source $(\rho')^{\otimes N}$ changes every decision risk with losses in $[0,1]$, and hence the optimal risk, by at most $w\|Y_0^{\otimes N}-Y_1^{\otimes N}\|_1/2$. A decision's conditional loss is the expectation of an effect between zero and the identity, and the benchmark difference is traceless. This gives the same comparison in both directions using the identity channel. At equal priors the multiplier is $1/4$. In particular $\Gamma=o(m\Delta)$ suffices along positive-deficit sequences with $N\Delta=O(1)$.

**Theorem 11.3 (Complete erasure of a coherent environment).** For $F=\mathbb C$ and $T=\operatorname{Tr}_E$, set $K=1+\sqrt2$. Then for every joint reference in the stated setting,
$$
d_{\rm B}^2(Y_0,P)\le (K+1/4)\Gamma,\qquad
\|Y_0^{\otimes N}-P^{\otimes N}\|_1\le\min\{2,2\sqrt{(K+1/4)N\Gamma}\}.
\tag{11.5}
$$
This includes singular $P$ and arbitrary reference coherences. In the bounded $N\Delta$ window, $\Gamma=o(\Delta)$ suffices for vanishing benchmark replacement error.

Proof. First let $L=|e\rangle\langle e|/q$ for unit $e$ and $q=\langle e,Qe\rangle$. Use a retained basis starting with $e$ and write the roots in retained-index blocks,
$$
\sqrt\sigma=\begin{pmatrix}A&B_0^\dagger\\ B_0&C_0\end{pmatrix},\qquad
\sqrt Q=\begin{pmatrix}a&\bar b\\ b&c\end{pmatrix}.
$$
Here $A,B_0,C_0$ are environmental Hilbert–Schmidt vectors, with $A,C_0$ Hermitian. Squaring the roots and taking the environmental trace gives
$$
\delta=a^2-\|A\|_2^2=c^2-\|C_0\|_2^2=\|B_0\|_2^2-|b|^2,\qquad
(a+c)b=\operatorname{Tr}((A+C_0)B_0).
$$
The first diagonal entry of the benchmark difference gives $\Gamma=\delta/q^2$. Set $h=(A+C_0)/(a+c)$, so $\|h\|_2\le1$ by $\delta\ge0$ and $\langle h,B_0\rangle=b$. With $t=(1-\|h\|_2^2)|b|^2$, expanding the squared norms gives $\|B_0-bh\|_2^2=\delta-t$ and $\|A-ah\|_2^2=ac(1-\|h\|_2^2)-\delta$. Thus $0\le t\le\delta$ and
$$
\|a B_0-bA\|_2\le a\sqrt{\delta-t}+\sqrt{ac\,t}
\le\sqrt{(a^2+ac)\delta}.
$$
The recomputed state is the projector onto $v=(a,b)^{\mathsf T}/\sqrt q$, where $q=a^2+|b|^2$. The transported state is the partial trace of the first block column times its adjoint, divided by $q$. Its mass on $(-\bar b,a)^{\mathsf T}/\sqrt q$ is therefore $\|aB_0-bA\|_2^2/q^2$. Since $f(Y_0,P)^2=\langle v,Y_0v\rangle$, this proves the rank-one estimate
$$
d_{\rm B}^2(Y_0,P)\le 2(a^2+ac)\Gamma\le K\Gamma.
\tag{11.6}
$$
The last inequality uses $a^2+c^2\le\operatorname{Tr}Q=1$ and the largest eigenvalue $K/2$ of $\left(\begin{smallmatrix}1&1/2\\1/2&0\end{smallmatrix}\right)$.

For general $L$ let $m=\lambda_{\min}(L)\in[0,1]$. At $m=1$, $L=I$ and the benchmarks coincide. Otherwise $L=mI+(1-m)L_*$ with $L_*$ rank one and $\operatorname{Tr}(QL_*)=1$. For any encoder the two benchmarks then mix those for $L_*$ with the shared component $m\sigma'$. Because $\mathcal D(I)=0$, $\Gamma=(1-m)^2\Gamma_*$. Joint concavity of root fidelity bounds the Bures square by $(1-m)d_{\rm B,*}^2$. In complete erasure this gives coefficient $K/(1-m)$. For $0<m<1$, (11.3) also gives $1/(4m)$. Their minimum is bounded by their common value $K+1/4$ at $m=1/(1+4K)$. The endpoint $m=0$ follows from (11.6), and (11.4) gives the tensor bound.

**Theorem 11.4 (Erasure inside retained sectors).** Let $E=\bigoplus_f E_f$ be any finite orthogonal decomposition and $\sigma=\bigoplus_f\sigma_f$. The channel $T$ records $f$ and traces out $E_f$. Then for every supported source, including sources with cross-sector coherences,
$$
d_{\rm B}^2(Y_0,Y_1)\le\min\{2,2^{5/3}\Gamma^{2/3}\}.
\tag{11.7}
$$
The bound is uniform over all sector dimensions and all $Q>0$. The sector hypothesis supplies equal benchmark masses on each retained label.

Proof. For the inclusion $J_f:E_f\hookrightarrow E$, the Kraus operators of $T$ are $|f\rangle\langle j|J_f^\dagger$ over an orthonormal basis $(|j\rangle)$ of each $E_f$. Their adjoint products sum to $I_E$. Put $Q_f=\operatorname{Tr}_{E_f}\sigma_f$ and $q_f=\operatorname{Tr}Q_f$. The benchmark blocks and their common masses are
$$
Y_{0,f}=\operatorname{Tr}_{E_f}\bigl[\sqrt{\sigma_f}(I_{E_f}\otimes L)\sqrt{\sigma_f}\bigr],
\quad Y_{1,f}=\sqrt{Q_f}L\sqrt{Q_f},\qquad p_f=\operatorname{Tr}(LQ_f).
$$
Cyclicity gives $\operatorname{Tr}Y_{i,f}=p_f$ and $\sum_f p_f=\sum_f q_f=1$. Put $\Gamma_f=\operatorname{Tr}L(Y_{1,f}-Y_{0,f})\ge0$ by the half-density comparison for the sector partial trace. Then $\Gamma=\sum_f\Gamma_f$. Zero masses give zero blocks. If $Q_f$ has rank one, positivity confines $\sigma_f$ to the same retained line, so both blocks equal $p_f$ times the projection onto that line.

Take $L=\lambda|e\rangle\langle e|$ first. Then $\lambda\ge1$ by $\operatorname{Tr}QL=1$. On a full-rank branch of positive mass, normalize the reference to $\sigma_f/q_f$ and the likelihood to $q_f L/p_f$. The benchmarks become $Y_{i,f}/p_f$, and the local defect is $q_f\Gamma_f/p_f^2$. For the diagonal entries $a,c$ of $\sqrt{Q_f/q_f}$ in the basis starting with $e$, $a^2\le p_f/(\lambda q_f)$ and $a+c\le\sqrt2$. Multiply (11.6) by $p_f$ and use additivity of root fidelity over direct sums. The contribution to the global Bures square is bounded by
$$
\min\!\left\{2p_f,\,2\sqrt2\,\Gamma_f\sqrt{\frac{q_f}{\lambda p_f}}\right\}
\le 2^{4/3}\Gamma_f^{2/3}(q_f/\lambda)^{1/3}.
$$
The last step is $\min(x,y)\le x^{1/3}y^{2/3}$. Hölder with exponents $3/2,3$ gives the sum bound $2^{4/3}\lambda^{-1/3}\Gamma^{2/3}$. For $m=\lambda_{\min}(L)<1/2$, the mixture argument of Theorem 11.3 costs a factor $(1-m)^{-1/3}\le2^{1/3}$. For $m\ge1/2$, (11.3) and the bound by two give $\min(2,\Gamma/2)\le\min(2,2^{5/3}\Gamma^{2/3})$.

Combining (11.7) with (11.4) gives the tensor bound $\min\{2,2\sqrt{2^{5/3}N\Gamma^{2/3}}\}$ and the same prior-weighted risk comparison. Thus $\Gamma=o(\Delta^{3/2})$ suffices when $N\Delta=O(1)$ along positive-deficit sequences.

**Proposition 11.5 (Sharp power and exact collective risk).** Use sectors of dimensions two and one, with the sector-erasure channel of Theorem 11.4. For $\varepsilon>0$ put $\Pi=|0\rangle\langle0|$ on the retained qubit and define
$$
Z_1=\varepsilon\Pi,\qquad Z_2=\begin{pmatrix}\varepsilon^2&\varepsilon\\\varepsilon&1\end{pmatrix},\qquad
R_0=Z_1^2+Z_2^2,\qquad n_\varepsilon=\operatorname{Tr}R_0=1+3\varepsilon^2+\varepsilon^4.
$$
Use $\sigma_0=(Z_1^2\oplus Z_2^2)/(2n_\varepsilon)$ in sector zero and $\sigma_1=I/4$ in sector one. Each sector has trace $1/2$. Set $Q=R_0/(2n_\varepsilon)+I/4\succeq I/4$, $\lambda=1/\langle0|Q|0\rangle$, and $P=\sqrt Q\,\lambda\Pi\sqrt Q$. The actual source is $\rho=0\oplus P$. It is a supported density with retained marginal $P$, and its likelihood is $L=\lambda\Pi$.

Since $Z_2^2=(1+\varepsilon^2)Z_2$, $R_{0,00}=2\varepsilon^2+\varepsilon^4$ and $\det R_0=\varepsilon^2(1+\varepsilon^2)$. By Cayley–Hamilton,
$$
\sqrt{R_0}=\frac{R_0+\sqrt{\det R_0}\,I}{\sqrt{n_\varepsilon+2\sqrt{\det R_0}}}.
$$
Its first column $(a_0,b_0)^{\mathsf T}$ has entries $\varepsilon+\varepsilon^2+O(\varepsilon^3)$ and $\varepsilon-\varepsilon^2+O(\varepsilon^3)$. Sector one has identical benchmark blocks. Since $\lambda\to4$, sector zero gives
$$
p_0=\frac{\lambda(2\varepsilon^2+\varepsilon^4)}{2n_\varepsilon}\sim4\varepsilon^2,\qquad
\Gamma=\frac{\lambda^2}{2n_\varepsilon}\bigl[a_0^2-\varepsilon^2-\varepsilon^4\bigr]\sim16\varepsilon^3.
$$
The normalized transported block is $\left(\begin{smallmatrix}1+\varepsilon^2&\varepsilon\\\varepsilon&1\end{smallmatrix}\right)/(2+\varepsilon^2)$, which tends to $I/2$. The normalized recomputed block is the projector onto $(a_0,b_0)^{\mathsf T}/\sqrt{2\varepsilon^2+\varepsilon^4}$, which tends to $|+\rangle=(|0\rangle+|1\rangle)/\sqrt2$. Its limiting root fidelity with the transported block is $1/\sqrt2$. Consequently $d_{\rm B}^2(Y_0,Y_1)\sim 4(2-\sqrt2)\varepsilon^2$, so $d_{\rm B}^2/\Gamma^\alpha$ diverges for every $\alpha>2/3$ even with $Q\succeq I/4$.

For $\varepsilon\downarrow0$ and integers $N\ge1$ with $N\varepsilon^2\to c\in[0,\infty)$, the number $J$ of sector-zero labels has law $\operatorname{Bin}(N,p_0)$ under both hypotheses. The product trace distance is the expectation of the conditional distance given the label string, since the labels form orthogonal blocks. Common sector-one factors have trace norm one. At fixed $J=j$, the conditional distance tends to $\|I/2^j-(|+\rangle\langle+|)^{\otimes j}\|_1=2(1-2^{-j})$. The distances are bounded by two and $\Pr(J>k)\le Np_0/(k+1)$, so the error in replacing the conditional distance by its limit tends to zero after truncation. Since $\mathbb E[2^{-J}]=(1-p_0/2)^N\to e^{-2c}$, the optimal equal-prior risk is
$$
\frac12-\frac14\|Y_0^{\otimes N}-Y_1^{\otimes N}\|_1\ \longrightarrow\ \frac12 e^{-2c}.
\tag{11.8}
$$
A measurement attaining this limit reads the labels, measures each sector-zero qubit in the $|+\rangle,|-\rangle$ basis, and declares $Y_0$ if any minus outcome occurs. At fixed $j$ its conditional errors under $Y_0$ and $Y_1$ tend to $2^{-j}$ and zero, respectively. The same tail bound gives the limiting average error.

For the actual pair, $D(\rho\Vert\sigma)=D(\rho'\Vert\sigma')=\log4$ because the encoder acts identically on sector one, which contains the source. Hence $\Delta_T=\Delta=\log4+\operatorname{Tr}(P\log Q)$. Direct expansion gives $Q_{00}=1/4+\varepsilon^2+O(\varepsilon^4)$ and $Q_{10}=\varepsilon/2+O(\varepsilon^3)$. With $\operatorname{Tr}Q=1$, the smaller eigenvalue is $1/4+\varepsilon^2/2+O(\varepsilon^4)$. The larger-eigenvalue projection has weight $\varepsilon^2+O(\varepsilon^4)$ in $|0\rangle$, by the formula $(Q-\lambda_{\min}(Q)I)/(\lambda_{\max}(Q)-\lambda_{\min}(Q))$. Multiplying that weight by $\lambda_{\max}(Q)/Q_{00}$ gives its weight in $P$, namely $3\varepsilon^2+O(\varepsilon^4)$. Therefore
$$
\Delta_T=\Delta=(2+3\log3)\varepsilon^2+O(\varepsilon^4),\qquad
\frac{\Gamma}{\Delta^{3/2}}\longrightarrow\frac{16}{(2+3\log3)^{3/2}}.
$$
In the window $N\Delta\to s\in[0,\infty)$, (11.8) is $\tfrac12\exp[-2s/(2+3\log3)]$.

A faithful version replaces $Z_i$ by $Z_i+\varepsilon^4 I$, recomputes the rare-sector normalization and $P$, and mixes the new pure source with weight $\varepsilon^8$ of the new $\sigma$. The perturbation of $R_0$ and its determinant is $O(\varepsilon^4)$, so the root formula changes its first column by $O(\varepsilon^3)$. The transported column norms squared change by $O(\varepsilon^5)$. These orders preserve the leading defect, mass and conditional limits. The $O(\varepsilon^4)$ perturbation of $Q$ preserves the entropy expansion, and the final source mixture changes the entropies by $O(\varepsilon^8\log(1/\varepsilon))$ by finite-dimensional entropy continuity and $\sigma\succeq c_0\varepsilon^8 I$ for some $c_0>0$ and small $\varepsilon$. The benchmark mixtures scale the defect by $(1-\varepsilon^8)^2$ and perturb each tensor benchmark in trace norm by at most $2N\varepsilon^8$. Entropy equality is exact because the rare sector of the mixed source is proportional to the reference and the encoder acts identically on sector one.

**Proposition 11.6 (The power for coherent references).** For arbitrary physical compression, (11.1) and the fidelity–trace distance inequality give $d_{\rm B}^2(Y_0,Y_1)\le\sqrt{\Gamma}$. The power $1/2$ is attained in order by a family with $Q\succeq I/4$ and a two-dimensional output environment. A three-dimensional output version preserves the same entropy loss exactly.

Proof. In the environment use three orthogonal labels. Put $\psi_1=|1\rangle$, $\psi_2=\sqrt{\varepsilon}|0\rangle+\sqrt{1-\varepsilon}|1\rangle$, and $\chi=(|1\rangle_E\otimes\psi_1+|2\rangle_E\otimes\psi_2)/\sqrt2$. Take the reference $\sigma=|\chi\rangle\langle\chi|/2+|3\rangle\langle3|\otimes I/4$. Then $Q=I/4+(|\psi_1\rangle\langle\psi_1|+|\psi_2\rangle\langle\psi_2|)/4$. Let $\lambda=4/(1+\varepsilon)$, $L=\lambda|0\rangle\langle0|$, and $P=\sqrt Q\,L\sqrt Q$. The actual source is $\rho=|3\rangle\langle3|\otimes P$, supported on $\sigma$.

Apply projective dephasing on the environmental labels. The root of the reference on labels 1 and 2 is $|\chi\rangle\langle\chi|/\sqrt2$. The likelihood expectation on $\chi$ is $\lambda\varepsilon/2$. The conditional benchmark states on the two labels are the respective $\psi_f$ projectors, with zero weight allowed. Both benchmarks share the block $L/4$ on label 3. Put $p=\varepsilon/(1+\varepsilon)$. The three probabilities are $(p/2,p/2,1-p)$ for $Y_0$ and $(0,p,1-p)$ for $Y_1$. Pairing their difference with $L$ gives $\Gamma=2p^2$, while their root fidelity is $1-p+p/\sqrt2$. Hence
$$
d_{\rm B}^2(Y_0,Y_1)=(\sqrt2-1)\sqrt{\Gamma},\qquad
\|Y_0^{\otimes N}-Y_1^{\otimes N}\|_1=2\bigl(1-(1-p/2)^N\bigr).
$$
For the second identity, on every label string with no 1 the transported probability is bounded by the recomputed one. The sum of their pointwise minima is therefore the transported probability of seeing no 1. The conditional quantum states are identical on those strings. Reading the labels and declaring $Y_0$ if any 1 appears achieves the optimal equal-prior error $(1-p/2)^N/2$.

The encoder is the identity on the reference block containing the source, so both actual relative entropies are $\log4$. The entries $Q_{00}=1/4+\varepsilon/4$, $Q_{11}=3/4-\varepsilon/4$, and $Q_{10}=\sqrt{\varepsilon(1-\varepsilon)}/4$ give a smaller eigenvalue $1/4+\varepsilon/8+O(\varepsilon^2)$. The weight of $|0\rangle$ on the larger eigenspace is $\varepsilon/4+O(\varepsilon^2)$ from its spectral projection. The weight in $P$ is $3\varepsilon/4+O(\varepsilon^2)$ after multiplying by the larger eigenvalue and dividing by $Q_{00}$. Thus
$$
\Delta_T=\Delta=(1/2+(3/4)\log3)\varepsilon+O(\varepsilon^2).
$$
Along $N\Delta\to s$, the optimal error converges to $\tfrac12\exp[-s/(1+(3/2)\log3)]$.

Grouping labels 1 and 3 and tracing out the group of dimension two gives an output of dimension two. The grouped reference block is $\operatorname{diag}(1/4,1/2)$. Its recomputed benchmark is $L/4$, and its transported block is $L/4+(p/2)|1\rangle\langle1|$. The two retained occupations are orthogonal. The benchmark on label 2 and all three effective probabilities are unchanged. The measurement reads the output label and the retained occupation on the grouped sector. This yields the same $\Gamma$, Bures distance, and exact product risk. By Theorem 11.3, output dimension one gives the linear bound.

Both examples have faithful versions with the same leading scales. Mix the reference with weight $\varepsilon^8$ of the normalized joint identity, recompute $P$ from the new reference marginal using the rank-one likelihood, then mix the source with weight $\varepsilon^8$ of the new reference. The marginal inverse remains uniformly bounded. The operator-norm square-root inequality for positive matrices bounds each joint or output square-root change by $O(\varepsilon^4)$. In fixed dimension each benchmark changes in trace norm by $O(\varepsilon^4)$. This preserves the leading defect and the critical product risk by tensor telescoping. The Bures distance changes by $O(\varepsilon^2)$, so the leading Bures square is preserved. For three labels the rare sector of the faithful source is proportional to the reference and the encoder is the identity on label 3. This preserves $\Delta_T=\Delta$. Finite-dimensional entropy continuity and the reference spectral floor of order $\varepsilon^8$ bound the change in $\Delta$ by $O(\varepsilon^8\log(1/\varepsilon))$.

### 11.7 Sources and verification

The ordinary recovery convention is the partial-trace instance of Petz's channel recovery formula. [Petz, *Sufficiency of channels over von Neumann algebras*](https://doi.org/10.1093/qmath/39.1.97)

Review `fac4dd900e4154acf8534d22`, attempt 1, verified the flagged determinant argument and derived the coherent complete-erasure extension and improved coefficient. Review `663d80464792b8a942002dae`, attempt 1, independently checked the half-density and POVM comparisons, the improved erasure bound, the sector normalizations and power bound, and the physical witness through the exact tensor trace-distance limit underlying (11.8). The attaining label-and-qubit measurement, entropy expansion with $\Delta_T=\Delta$, and faithful variant are additional derivations on that witness. Review `36f213dd15a16d9e26e2cf9f`, attempt 1, independently checked the general square-root bound, the coherent three-label witness, its exact entropy equality and risk, and its faithful approximation. The two-label version follows by grouping two labels while the retained occupations still distinguish the transported mass. Each power is optimal within its stated class. The displayed prefactors are upper bounds. The risk limit compares the two encoded benchmarks.

## 追加锚（本行以下为增补区）

## 12. Testing against the same encoded source

**Theorem 12.1 (Exact entropy preservation and strict risk separation).** There is a five-flag dephasing family with $Q\succeq I/4$ and $\Delta_T=\Delta$ exactly. As $\varepsilon\downarrow0$, it satisfies $\Gamma/\varepsilon^2\to2$ and $\Delta/\varepsilon\to1+3\log(3/2)$. Let $r_{i,N}$ be the minimum equal-prior error for testing the encoded source $R$ against $Y_i$ on $N$ copies. For integers $N$ with $N\varepsilon\to c>0$, put $A_c=\operatorname{Pois}(3c/2)^{\otimes2}$ and $B_c=\operatorname{Pois}(c)\otimes\operatorname{Pois}(2c)$. Then

$$
r_{0,N}\longrightarrow r_0(c)=\tfrac12 e^{-c},\qquad
r_{1,N}\longrightarrow r_1(c)=\tfrac12\sum_{k,\ell\ge0}
\min\{A_c(k,\ell),e^{-c}B_c(k,\ell)\}<r_0(c).
$$

Both the source and reference can be chosen faithful with the same exact entropy equality and limits.

Proof. Use the tensor order $E\otimes B$ of Proposition 11.6. Take orthonormal flags $(1,+),(2,+),(1,-),(2,-),3$. For $0<\varepsilon<1/3$ set $w=1/2$, $a=1/4$, $t=3\varepsilon$, and

$$
v_\pm=\sqrt{\varepsilon}|0\rangle\pm\sqrt{1-\varepsilon}|1\rangle,\qquad
\chi_\pm=\frac{|1,\pm\rangle\otimes|1\rangle+|2,\pm\rangle\otimes v_\pm}{\sqrt2},
$$

$$
\sigma=\frac w2\sum_\pm|\chi_\pm\rangle\langle\chi_\pm|+a|3\rangle\langle3|\otimes I,\qquad
\rho=\frac t2\sum_\pm|\chi_\pm\rangle\langle\chi_\pm|+(1-t)|3\rangle\langle3|\otimes|0\rangle\langle0|.
$$

Let $T$ be pinching by the five flag projections and $\Phi=T\otimes\mathrm{id}_B$. The source is supported on the reference. On each four-dimensional flag-pair sector the conditional states agree before and after pinching. The two sectors have source mass $t/2$ and reference mass $w/2$ each. The flag-3 block is fixed, and the source there lies on the reference eigenvalue $a$. Hence

$$
D(\rho\Vert\sigma)=D(\Phi\rho\Vert\Phi\sigma)
=t\log(t/w)+(1-t)\log((1-t)/a).
$$

Pinching preserves the partial trace over $E$, so subtracting the actual marginal relative entropy gives $\Delta_T=\Delta$. Each $\chi_\pm$ has retained marginal $(|1\rangle\langle1|+|v_\pm\rangle\langle v_\pm|)/2$. The off-diagonal entries cancel between the signs, giving

$$
P=\operatorname{diag}(1-u,u),\quad u=t(1-\varepsilon/2),\qquad
Q=\operatorname{diag}(q_0,q_1),\quad q_0=(1+\varepsilon)/4,\quad q_1=(3-\varepsilon)/4.
$$

For the marginal term write $f(x)=(1-x)\log((1-x)/q_0)+x\log(x/q_1)$. On $[u,t]$ its derivative $\log(xq_0/((1-x)q_1))$ is $O(\log(1/\varepsilon))$. Since $t-u=3\varepsilon^2/2$, replacing $f(u)$ by $f(t)$ gives

$$
\Delta=(1-t)\log(q_0/a)+t\log(q_1/w)+O(\varepsilon^2\log(1/\varepsilon))
=(1+3\log(3/2))\varepsilon+O(\varepsilon^2\log(1/\varepsilon)).
$$

Put $L=Q^{-1/2}PQ^{-1/2}=\operatorname{diag}(L_0,L_1)$, with $L_0=(1-u)/q_0$ and $L_1=u/q_1$. Set $\mu_1=L_1$ and $\mu_2=\varepsilon L_0+(1-\varepsilon)L_1$. For a joint reference $C$ with marginal $Q$, its ordinary Petz benchmark is $\sqrt C(I_E\otimes L)\sqrt C$. On either coherent pair the reference root is $\sqrt{w/2}|\chi_\pm\rangle\langle\chi_\pm|$, and the likelihood expectation is $(\mu_1+\mu_2)/2$. Pinching splits the resulting mass equally between the two flags. For the recomputed benchmark each dephased reference block has coefficient $w/4$ on its retained rank-one projector and is weighted by $\mu_1$ or $\mu_2$. Both benchmark blocks on flag 3 are $aL$.

Read the flag and, on flag 3, the retained occupation. The conditional pure state on each of the first four flags is common to all hypotheses, and the sign is fair within each flag class under all three. In the order of classes 1 and 2 followed by occupations 1 and 0 on flag 3, the exact probabilities are

$$
\begin{aligned}
R=\Phi\rho &\quad (t/2,t/2,0,1-t),\\
Y_0 &\quad (w(\mu_1+\mu_2)/4,w(\mu_1+\mu_2)/4,aL_1,aL_0),\\
Y_1 &\quad (w\mu_1/2,w\mu_2/2,aL_1,aL_0).
\end{aligned}
$$

Pairing the first two mass differences with $\mu_1,\mu_2$ gives

$$
\Gamma=\operatorname{Tr}[(I_E\otimes L)(Y_1-Y_0)]
=\frac w4(\mu_2-\mu_1)^2=\frac w4\varepsilon^2(L_0-L_1)^2.
$$

Since $L_0\to4$ and $L_1/\varepsilon\to4$, this gives $\Gamma/\varepsilon^2\to2$. Also $\mu_1/\varepsilon\to4$ and $\mu_2/\varepsilon\to8$, so the first three probabilities divided by $\varepsilon$ tend respectively to $(3/2,3/2,0)$, $(3/2,3/2,1)$, and $(1,2,1)$.

The orthogonal flag and occupation blocks have common conditional states, so the cell measurement preserves the trace distance on every tensor power. Given the first three counts, the fourth is determined and the ordered cell string is uniform under each hypothesis. The count likelihood ratio test therefore attains the quantum optimum at each $N$, with error equal to half the sum of the pointwise minima of the count masses. For rare probabilities $p_1,p_2,p_3$, the mass at fixed counts $n_1,n_2,n_3$ with $s=\sum_j n_j$ is

$$
(N)_s\prod_{j=1}^3\frac{p_j^{n_j}}{n_j!}\left(1-\sum_{j=1}^3p_j\right)^{N-s}
\longrightarrow
e^{-\sum_j\lambda_j}\prod_{j=1}^3\frac{\lambda_j^{n_j}}{n_j!},
\qquad \lambda_j=\lim Np_j.
$$

Here $(N)_s=N!/(N-s)!$, and a zero rate gives a count identically zero in the limit. The expected total count stays bounded, so Markov's inequality bounds the tails uniformly. The limiting law also has finite mean. Summing over finite count sets and bounding both tails gives total variation convergence under each hypothesis, hence convergence of the minimum errors.

The source has third count zero, and each limiting benchmark has an independent $\operatorname{Pois}(c)$ third count. Only third count zero contributes to either overlap. The first two counts have law $A_c$ for both $R$ and $Y_0$, and law $B_c$ for $Y_1$. This yields the two stated limits. For every $c>0$, choose an integer $\ell>c/\log(4/3)$. At $(0,\ell)$ the ratio $A_c(0,\ell)/B_c(0,\ell)=(3/4)^\ell$ is strictly below $e^{-c}$ and $B_c(0,\ell)>0$. The overlap with $e^{-c}B_c$ is strictly less than its total mass $e^{-c}$. Every window $N\Delta\to d>0$ gives this comparison at $c=d/(1+3\log(3/2))$.

For the faithful version let $\delta=\varepsilon^8$ and $\sigma_\delta=(1-\delta)\sigma+\delta I_{10}/10$. On each flag-pair sector take the source block to be $t/2$ times the normalized restriction of $\sigma_\delta$. On flag 3 take $(1-t)((1-\delta)|0\rangle\langle0|+\delta I/2)$. Both states are positive definite. The pair contributions depend only on the sector masses before and after pinching, and the common block is fixed, so the joint entropy equality and $\Delta_T=\Delta$ hold exactly.

The new total reference mass of the two pairs is $w_\delta=(1-\delta)w+4\delta/5$, and its flag-3 eigenvalue is $a_\delta=(1-\delta)a+\delta/10$. The new joint relative entropy is

$$
t\log(t/w_\delta)+(1-t)\bigl[\log((1-t)/a_\delta)-h(\delta/2)\bigr],
$$

where $h(x)=-x\log x-(1-x)\log(1-x)$. Its change is $O(\delta\log(1/\delta))$. Both joint states and their marginals change by $O(\delta)$ in trace norm. The uniform marginal reference floor and finite-dimensional entropy continuity give the same $O(\delta\log(1/\delta))$ bound for the change in $D(P\Vert Q)$.

Recomputing the likelihood from these marginals changes it by $O(\delta)$ in operator norm by the uniform floor. The positive square-root inequality bounds each reference-root change by $O(\sqrt\delta)$ in operator norm. Expanding the Petz sandwiches in fixed dimension and using trace-norm contractivity of $\Phi$ bounds each benchmark change by $O(\sqrt\delta)$ in trace norm. The trace pairing then changes $\Gamma$ by $O(\sqrt\delta)=o(\varepsilon^2)$. By tensor telescoping and the Helstrom formula, each optimal error changes by at most

$$
\frac N4\bigl(\|R_\delta-R\|_1+\|Y_{i,\delta}-Y_i\|_1\bigr)=O(N\varepsilon^4)\longrightarrow0.
$$

Independent review `727b4068155cab3df32dd99b`, attempt 1, approved the construction and checked the entropy identities, benchmark probabilities, defect, finite-copy optimum, Poisson limits, strict comparison, and faithful perturbation with no equation corrections. Lean formalization of Theorem 12.1 is ongoing.

## 追加锚（本行以下为增补区）

## 13. An explicit gap for binary commuting retained marginals

The earlier weighted Gram analysis of commuting retained marginals proved a dimension-independent qualitative gap below six at retained reference rank two by ruling out sequences of scores tending to six. This section quantifies that gap and gives two criteria for transferring the resulting estimate to the original recovery at noncommuting retained marginals.

**Theorem 13.1 (Uniform binary commuting-output bound).** Let $\Phi$ be a finite-dimensional CPTP map and let $\rho,\sigma$ be density matrices with $\operatorname{supp}\rho\subseteq\operatorname{supp}\sigma$. Write $P=\Phi(\rho)$ and $Q=\Phi(\sigma)$ for the actual retained marginals. Suppose $\operatorname{rank}Q=2$ and $[P,Q]=0$. With natural logarithms and the unhalved trace norm, set

$$
\begin{aligned}
\mathcal R_{\sigma,\Phi}(X)&=
\sqrt{\sigma}\,\Phi^\dagger(Q^{-1/2}XQ^{-1/2})\sqrt{\sigma},\\
R&=\mathcal R_{\sigma,\Phi}(P),\qquad
\Delta=D(\rho\Vert\sigma)-D(P\Vert Q),\qquad
C=\frac{59999}{10000}.
\end{aligned}
$$

Here $\Phi^\dagger$ is the trace adjoint and the inverse is taken on $\operatorname{supp}Q$. Then

$$
\|\rho-R\|_1^2\le C\Delta.
\tag{13.1}
$$

The bound holds for every binary POVM on an arbitrary finite-dimensional input, including the rank-one reference case. The optimal uniform coefficient at retained reference rank two remains open.

Proof. On $\operatorname{supp}\sigma$, each positive input is dominated by a finite multiple of $\sigma$. It therefore has output supported on $\operatorname{supp}Q$. The restricted channel is CPTP, and $\mathcal R_{\sigma,\Phi}$ is CPTP on $\operatorname{supp}Q$ because the formula is completely positive and its trace is $\operatorname{Tr}(Q Q^{-1/2}XQ^{-1/2})=\operatorname{Tr}X$ there.

Use a finite Stinespring isometry $V$ into $E\otimes K$, with $K=\operatorname{supp}Q$ after the channel restriction. Put $A=V\rho V^\dagger$ and $B=V\sigma V^\dagger$. Partial trace over $E$ gives $P,Q$. For a retained operator $L$ write $\widehat L=I_E\otimes L$. Since $\sqrt B=V\sqrt{\sigma}V^\dagger$ and the restricted channel has adjoint $L\mapsto V^\dagger\widehat L V$, the partial-trace Petz return is $VRV^\dagger$. Isometric invariance preserves the joint relative entropy and the trace error.

First take $A,B$ faithful on $E\otimes K$. In a common retained eigenbasis let $p_i,q_i$ be the respective eigenvalues of $P,Q$ and $F_i$ the lifted eigenprojections for $i=0,1$. Order the likelihoods as $h=h_0=p_0/q_0\le h_1=p_1/q_1$, so that $h\le1\le h_1$ by $\sum_i q_i h_i=1$. Define

$$
\begin{aligned}
S_i&=\sqrt A F_i, & T_i&=\sqrt{h_i}F_i\sqrt B, & W_i&=S_i-T_i,\\
S&=\sum_i S_i=\sqrt A, & T&=\sum_i T_i, & W&=\sum_i W_i=S-T.
\end{aligned}
$$

The two families $(S_i)_i$ and $(T_i)_i$ are each orthogonal for the Hilbert–Schmidt pairing $\langle X,Y\rangle=\operatorname{Tr}(X^\dagger Y)$ by $F_0F_1=0$ and cyclicity of trace. Their squared norms satisfy $\|S_i\|_2^2=p_i=\|T_i\|_2^2$ by the actual partial traces. Thus $\|S\|_2=\|T\|_2=1$, with $S^\dagger S=A$ and $T^\dagger T$ equal to the partial-trace return.

Take matrix entries with the eigenbasis of $A$ on the left and that of $B$ on the right, with eigenvalues $\mu_\alpha,\lambda_\beta$, respectively. At entry $(\alpha,\beta)$ set

$$
a_i=h_i\lambda_\beta/\mu_\alpha,\qquad x_i=\log a_i,\qquad
z_i=(S_i)_{\alpha\beta},\qquad \delta_i=(1-\sqrt{a_i})z_i.
$$

The entry of $T_i$ is $\sqrt{a_i}z_i$, and $\delta_i=(W_i)_{\alpha\beta}$. For $a,b>0$ define the scalar kernels

$$
\begin{aligned}
f(a)&=\frac{a\log a}{a-1},&
\mathcal B(a,b)&=(1+\sqrt a)(1+\sqrt b)\frac{f(a)-f(b)}{a-b},\\
K(t)&=\frac{t/2}{\sinh(t/2)},&
c(t)&=\frac{t}{2}\coth(t/2).
\end{aligned}
$$

Use continuous values at removable singularities. In particular $K(0)=c(0)=1$. Direct expansion of the divided difference gives

$$
\begin{aligned}
\mathcal L(x,y)
&=(1-e^{x/2})(1-e^{y/2})\mathcal B(e^x,e^y)\\
&=\frac{e^x x(e^y-1)-e^y y(e^x-1)}{e^x-e^y}\\
&=-\frac{x+y}{2}+e^{(x+y)/2}K(x-y)-c(x-y).
\end{aligned}
\tag{13.2}
$$

Write $\mathbf B_{\alpha\beta}=(\mathcal B(a_i,a_j))_{i,j=0,1}$. In the sum of $\delta^\dagger\mathbf B_{\alpha\beta}\delta$ over spectral entries, the $K$ and $c$ terms in (13.2) have off-diagonal sums zero separately. Indeed $x_i-x_j=\log(h_i/h_j)$ is constant across entries, and the corresponding pairings are those of $T_i,T_j$ and $S_i,S_j$. On the diagonal the two terms sum to $\|T_i\|_2^2-\|S_i\|_2^2=0$. Splitting the linear term into the common spectral logarithm and the two likelihood logarithms yields

$$
\begin{aligned}
\sum_{\alpha,\beta}\delta^\dagger\mathbf B_{\alpha\beta}\delta
&=-\sum_{\alpha,\beta}\log(\lambda_\beta/\mu_\alpha)|S_{\alpha\beta}|^2
  -\sum_i p_i\log h_i\\
&=D(A\Vert B)-D(P\Vert Q)=\Delta.
\end{aligned}
\tag{13.3}
$$

The likelihood contribution uses $\sum_{\alpha,\beta}\overline z_i z_j=0$ for $i\ne j$ and $\sum_{\alpha,\beta}|z_i|^2=p_i$. In the spectral contribution $|S_{\alpha\beta}|^2$ is $\mu_\alpha$ times the squared overlap of the eigenvectors, which gives the joint entropy.

Let $G_{ij}=K(\log(h_i/h_j))$ and $g=G_{01}=K(\log(h_1/h))$. Applying (13.2) at $(x,y)$ and $(x/2,y/2)$ and using $K(t/2)=\cosh(t/4)K(t)$ and $2c(t/2)-c(t)=K(t)$ gives $\mathcal L(x,y)-2\mathcal L(x/2,y/2)=(1-e^{x/2})(1-e^{y/2})K(x-y)$. Dividing by $(1-e^{x/2})(1-e^{y/2})$ and extending by continuity gives

$$
\mathcal B(a,b)-K(\log(a/b))
=\frac{2\mathcal B(\sqrt a,\sqrt b)}{(1+a^{1/4})(1+b^{1/4})},
\qquad
\mathcal B(a,b)=(1+\sqrt a)(1+\sqrt b)
\int_0^\infty\frac{t\,dt}{(1+t)(a+t)(b+t)}.
\tag{13.4}
$$

The integral follows by taking the divided difference in $f(a)=\int_0^\infty a\,dt/((1+t)(a+t))$. It exhibits $\mathbf B_{\alpha\beta}-G$ as a Gram matrix with nonnegative entries. Also $G=\left(\begin{smallmatrix}1&g\\g&1\end{smallmatrix}\right)$ with $0<g\le1$. At the first diagonal entry the remainder is $r(a_0)$, where differentiation of $f$ gives

$$
r(a)=\mathcal B(a,a)-1=\int_0^1\frac{2u\,du}{1+(\sqrt a-1)u}
\ge \frac{3}{1+2\sqrt a}.
\tag{13.5}
$$

The inequality is Jensen's inequality for the probability measure $2u\,du$.

At each entry rotate both $\delta_i$ by a common phase to make their sum real and nonnegative. Taking real parts $d_i$ preserves this sum and can only decrease the energy because $\mathbf B_{\alpha\beta}$ is real symmetric positive semidefinite. If $d_0d_1<0$, the logistic form obeys $d^{\mathsf T}Gd=(d_0+d_1)^2+2(g-1)d_0d_1\ge(d_0+d_1)^2$. When both real parts are nonnegative, (13.4) gives energy at least $(1+r(a_0))d_0^2+d_1^2$. Weighted Cauchy–Schwarz gives coefficient $(1+r(a_0))/(2+r(a_0))$ for the squared sum in this case. A zero sum is covered by positivity. In either case,

$$
\delta^\dagger\mathbf B_{\alpha\beta}\delta
\ge \left(\frac12+\frac1{m(a_0)}\right)|W_{\alpha\beta}|^2,
\qquad m(a)=2+\frac4{r(a)}.
\tag{13.6}
$$

Put $e=\|A-T^\dagger T\|_1$ and $w=\|W\|_2$. Take $Z$ to be the Hermitian unitary sign of $A-T^\dagger T$, assigning either sign on its kernel. Let $Y=SZ$, $b=|\langle Y,W\rangle|$, and at each entry set $x=\sqrt{a_0}$. The entries of $xY$ are exactly those of $Y'=\sqrt h\,Z\sqrt B$, since the factor $\sqrt{\lambda_\beta/\mu_\alpha}$ cancels the left spectral factor of $\sqrt A$ and supplies the right spectral factor of $\sqrt B$. The weights $|Y_{\alpha\beta}|^2$ have total mass one. In this probability law, with $m_1=\mathbb E[x]$, one has

$$
\mathbb E[x^2]=h,\qquad m_1\le\sqrt h\le1,\qquad
\mathbb E[(x-1)^2]=\|Y-Y'\|_2^2=1+h-2m_1.
\tag{13.7}
$$

Sum (13.6) and apply weighted Cauchy–Schwarz to the $Y,W$ pairing. By (13.5),

$$
\Delta\ge \frac{w^2}{2}+\frac{b^2}{N},\qquad
N=\sum_{\alpha,\beta}m(a_0)|Y_{\alpha\beta}|^2
\le 2+\frac43(1+2m_1)\le6.
\tag{13.8}
$$

Expanding $S^\dagger S-T^\dagger T$ gives $e=\operatorname{Re}\langle SZ,W\rangle+\operatorname{Re}\langle TZ,W\rangle$. The real pairings are each at most $w$, so $e\le2w$ and $e\le b+w$. Using $N\le6$ and $e^2\le2(b^2+w^2)$ in (13.8) yields $\Delta\ge w^2/3+e^2/12$. This also gives $e=0$ at zero loss.

Set $\varepsilon=1/10000$ and suppose $e>0$ and $e^2\ge(6-\varepsilon)\Delta$. The reciprocal bound $1/(6-\varepsilon)\le1/6+\varepsilon/30$ gives $w^2/e^2\le1/4+\varepsilon/10$. The inequality $(1+t)^{-1/2}\ge1-t/2$ for $t\ge0$, together with $e\le2w$, now gives

$$
\frac{e}{w}\ge 2-\frac{2\varepsilon}{5},\qquad
\frac{\Delta}{w^2}\le\frac{4}{6-\varepsilon}\le \frac23+\frac{\varepsilon}{8}.
\tag{13.9}
$$

The real pairing with $Y$ is at least $e-w$. It follows that $\|W/w-Y\|_2^2\le 4\varepsilon/5\le\varepsilon$ and $b/w\ge1-2\varepsilon/5$. Equations (13.8)–(13.9) force

$$
N\ge\frac{(1-2\varepsilon/5)^2}{1/6+\varepsilon/8}\ge6-10\varepsilon.
\tag{13.10}
$$

The last inequality has cleared-denominator slack $7\varepsilon/60+141\varepsilon^2/100$. The upper bound on $N$ gives $m_1\ge1-15\varepsilon/4$. Using $m_1^2\le h\le1$ in (13.7) gives both $1-h\le15\varepsilon/2$ and $\|Y-Y'\|_2^2\le15\varepsilon/2$.

Suppose first that $g\ge1/4$. At entries with $|x-1|\le1/8$, (13.5) gives $r(a_0)\ge12/13$. Use the same rotation and real parts as in (13.6). Opposite signs give coefficient at least one for the squared sum. For two nonnegative real parts of positive sum, put $u=d_0/(d_0+d_1)$. Keeping the logistic cross term and the first diagonal remainder gives the normalized lower bound

$$
(1+r(a_0))u^2+(1-u)^2+2g u(1-u)
\ge 1-\frac32u+\frac{63}{26}u^2\ge\frac{43}{56}.
$$

The final number is the minimum of the quadratic. Zero sums are covered by positivity. On the complementary entries with $|x-1|>1/8$, the restriction of $Y$ has Hilbert–Schmidt norm at most $8\|Y-Y'\|_2<24\sqrt{\varepsilon}$. The restriction of $W/w$ there has norm at most $25\sqrt{\varepsilon}$. By (13.3) the remaining entries then give

$$
\frac{\Delta}{w^2}\ge\frac{43}{56}(1-25^2\varepsilon)=\frac{645}{896}.
$$

This exceeds the upper bound $2/3+\varepsilon/8$ by $44677/840000$.

Suppose now that $g<1/4$. The function $K$ decreases on $[0,\infty)$ since $s\cosh s>\sinh s$ for $s>0$. The identity $K(\log 64)=16\log 2/21>8/21>1/4$ uses $\log 2=\int_1^2 dt/t>1/2$. Hence $h_1/h>64$. The probability identities give $p_1(1-h/h_1)=1-h$ and $q_1\le p_1$, so $p_1\le(15/2)(64/63)\varepsilon<8\varepsilon$. Unitarity of $Z$ and the two true partial traces give $\|F_1Y\|_2^2=p_1$ and $\|Y'F_1\|_2^2=h q_1$. Approximating $W/w$ on the left by $Y$ and on the right by $Y'$ gives

$$
\begin{aligned}
\|F_1W\|_2/w &\le \sqrt{p_1}+\sqrt{\varepsilon}\le4\sqrt{\varepsilon},\\
\|WF_1\|_2/w &\le \sqrt{h q_1}+\sqrt{\varepsilon}+\sqrt{15\varepsilon/2}\le7\sqrt{\varepsilon}.
\end{aligned}
$$

The two opposite blocks satisfy

$$
\begin{aligned}
F_0WF_1 &= F_0SF_1-\sqrt h\,F_0\sqrt B F_1,\\
(F_1WF_0)^\dagger &= F_0SF_1-\sqrt{h_1}\,F_0\sqrt B F_1 .
\end{aligned}
$$

Subtracting gives $\sqrt h\|F_0\sqrt B F_1\|_2\le (11/7)w\sqrt{\varepsilon}$ because $\sqrt{h_1/h}-1>7$. The first block identity gives $\|F_0SF_1\|_2\le (7+11/7)w\sqrt{\varepsilon}$. Self-adjointness of $S$ gives $\|[S,F_1]\|_2=\sqrt 2\|F_0SF_1\|_2<13w\sqrt{\varepsilon}$, using $2(7+11/7)^2<13^2$. Hence $W_1=F_1W+[S,F_1]$ has $\|W_1\|_2\le17w\sqrt{\varepsilon}$.

Summing the logistic part of (13.4) yields the full two-term energy estimate

$$
\begin{aligned}
\Delta
&\ge \|W_0\|_2^2+\|W_1\|_2^2+2g\operatorname{Re}\langle W_0,W_1\rangle\\
&=w^2-2(1-g)\operatorname{Re}\langle W-W_1,W_1\rangle.
\end{aligned}
$$

For $v=\|W_1\|_2/w$ one has $0\le v\le17/100$ and $\operatorname{Re}\langle W-W_1,W_1\rangle/w^2\le v-v^2$ by Cauchy–Schwarz. Since $0\le1-g\le1$ and $v-v^2\ge0$, it follows that

$$
\frac{\Delta}{w^2}\ge1-2v+2v^2\ge\frac{3589}{5000}.
$$

The quadratic decreases on the stated interval and the last value exceeds $2/3+\varepsilon/8$ by $12269/240000$. This is the second contradiction to (13.9) and proves the faithful estimate.

To pass to the supported $A,B$ from the Stinespring reduction, set $B_*=(I_E/\dim E)\otimes Q$ and put $A_\tau=(1-\tau)A+\tau B_*$ and $B_\tau=(1-\tau)B+\tau B_*$ for $\tau\in(0,1)$. These approximants are faithful, with retained pair $((1-\tau)P+\tau Q,Q)$, which commutes at the same reference rank. Joint convexity gives $D(A_\tau\Vert B_\tau)\le(1-\tau)D(A\Vert B)$. Lower semicontinuity then gives convergence to the finite $D(A\Vert B)$. The retained relative entropy converges by continuity of $x\log x$ and the fixed positive reference on $K$. Continuity of the square root and the fixed supported inverse give convergence of the Petz return in trace norm. The closed inequality (13.1) passes to the limit, including singular retained $P$. A binary POVM produces diagonal retained matrices. If its reference has rank one, $P=Q$ by support inclusion, $R=\sigma$, and Pinsker's inequality gives $\|\rho-R\|_1^2\le2\Delta$.

**Corollary 13.2 (Transfer through either physical output pinching).** Keep the supported input pair, reference output rank two and definitions of Theorem 13.1, allowing arbitrary $P,Q$ on $K$. Let $P_0$ be the pinching of $P$ in an eigenbasis of $Q$, and $Q_0$ the pinching of $Q$ in an eigenbasis of $P$. Define

$$
j_P=D(P\Vert P_0),\qquad
j_Q=D(P\Vert Q)-D(P\Vert Q_0)=\operatorname{Tr}P(\log Q_0-\log Q).
$$

Then the return of the original channel satisfies

$$
\|\rho-R\|_1\le
\min\!\left\{
\sqrt{C(\Delta+j_P)}+\sqrt{2j_P},
\ \sqrt{C(\Delta+j_Q)}+2\sqrt{1-e^{-j_Q}}
\right\}.
\tag{13.11}
$$

In particular, if either $j=j_P$ or $j=j_Q$ satisfies

$$
j\le \left(\frac{\sqrt6-\sqrt C}{\sqrt C+2}\right)^2\Delta,
\tag{13.12}
$$

then $\|\rho-R\|_1^2\le6\Delta$. The constants are independent of the smallest positive eigenvalue of $Q$.

Proof. Compose the restricted channel with pinching in a $Q$ eigenbasis. The actual output pair becomes $P_0,Q$. The relative entropy removed from the output is $D(P\Vert Q)-D(P_0\Vert Q)=D(P\Vert P_0)$ because the trace against both diagonal logarithms depends only on $P_0$. A zero diagonal of $P_0$ gives a zero row and column of $P$ by positivity, so the identity applies on the corresponding support. The pinched channel has loss $\Delta+j_P$. The pinching is self-adjoint for the trace pairing and fixes $Q^{-1/2}P_0Q^{-1/2}$. The ordinary Petz return for this channel is therefore $\mathcal R_{\sigma,\Phi}(P_0)$. Contractivity of the supported Petz channel and natural-log Pinsker give

$$
\|R-\mathcal R_{\sigma,\Phi}(P_0)\|_1\le \|P-P_0\|_1\le\sqrt{2j_P}.
$$

Theorem 13.1 and the triangle inequality give the first estimate in (13.11).

For pinching in a $P$ eigenbasis, the output pair becomes $P,Q_0$. Here $Q_0$ is positive on $K$, and data processing under the pinching gives $j_Q\ge0$. The new loss is $\Delta+j_Q$. Use the same Stinespring isometry as in the theorem and write the original and pinched Petz returns on its range as $UU^\dagger$ and $U_0U_0^\dagger$, where

$$
U=\sqrt B\,\widehat{Q^{-1/2}P^{1/2}},\qquad
U_0=\sqrt B\,\widehat{Q_0^{-1/2}P^{1/2}}.
$$

The second formula uses the adjoint of the output pinching, which fixes the diagonal $Q_0^{-1/2}P Q_0^{-1/2}$. Both amplitudes have Hilbert–Schmidt norm one. For $U_0$ the squared norm is $\operatorname{Tr}(Q Q_0^{-1/2}P Q_0^{-1/2})=\operatorname{Tr}P$ by diagonality in the $P$ basis. If $p_i$ are the eigenvalues of $P$ in that basis and $q_i=\langle i|Q|i\rangle$, then

$$
\langle U,U_0\rangle=\operatorname{Tr}(P Q^{1/2}Q_0^{-1/2})
=\sum_i p_i\frac{\langle i|\sqrt Q|i\rangle}{\sqrt{q_i}}.
$$

Spectral Jensen gives $\langle i|\sqrt Q|i\rangle/\sqrt{q_i}\ge e^{-\ell_i/2}$ for $\ell_i=\log q_i-\langle i|\log Q|i\rangle$. Jensen under the probabilities $p_i$ gives $\langle U,U_0\rangle\ge e^{-j_Q/2}$ since $\sum_i p_i\ell_i=j_Q$. The vectorizations are unit purifications of the two returns, so trace-norm contractivity under partial trace and the pure-state trace formula bound the unhalved distance of the returns by $2\sqrt{1-e^{-j_Q}}$. The argument permits zero eigenvalues of $P$. Applying Theorem 13.1 to the pinched channel and taking the triangle inequality proves the second estimate in (13.11).

Each estimate is at most $\sqrt{C(\Delta+j)}+2\sqrt j\le\sqrt{C\Delta}+(\sqrt C+2)\sqrt j$ for the respective loss. Under (13.12) the upper bound is $\sqrt{6\Delta}$.

### 13.3 Sources and verification

The ordinary channel recovery formula is Petz's. Yang's faithful Poisson-strip identity represents the same entropy loss in strip form. Equations (13.2)–(13.4) derive the spectral Gram representation used here directly for commuting retained marginals. [Petz, *Sufficiency of channels over von Neumann algebras*, QJM 39 (1988), 97–108](https://doi.org/10.1093/qmath/39.1.97) · [Yang, *Quantum data processing equality*, arXiv:2609.33815v2, Theorem II.1 and Eq. (II.5)](https://arxiv.org/html/2609.33815v2#S2.E5)

The two contradiction margins were checked by exact rational arithmetic.

## 追加锚（本行以下为增补区）
